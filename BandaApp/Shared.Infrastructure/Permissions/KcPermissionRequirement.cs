using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Shared.ExceptionHandling;
using Shared.Infrastructure.DTOS;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Shared.Infrastructure.Permissions
{
    public class KcPermissionRequirement : IAuthorizationRequirement
    {
        public KcPermissionRequirement(string permission) =>
            Permission = permission;

        public string Permission { get; }
    }

    public class PermissionRequirementHandler : AuthorizationHandler<KcPermissionRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;


        public PermissionRequirementHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        private static async Task<UserInfoDto> GetUserInfoAsync(string token)
        {
            var AuthServerUrl = SharedSettings.kcAuthUrl;
            var Realm = SharedSettings.kcRealm;

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{AuthServerUrl}/realms/{Realm}/protocol/openid-connect/userinfo");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(content))
                    {
                        var objDeserializeObject = JsonSerializer.Deserialize<UserInfoDto>(content);
                        if (objDeserializeObject != null)
                        {
                            return objDeserializeObject;
                        }
                    }
                }
            }

            throw new UnauthorizedException(SharedResources.UnauthorizedMessage, HttpStatusCode.Unauthorized);
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, KcPermissionRequirement requirement)
        {
            try
            {

                string authorization = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

                if (string.IsNullOrEmpty(authorization)) throw new UnauthorizedException(SharedResources.UnauthorizedMessage, HttpStatusCode.Unauthorized);

                string accessToken = authorization.Split(" ")[1];

                var user = await GetUserInfoAsync(accessToken);

                //_httpContextAccessor.HttpContext.User.AddIdentity()

                var roles = GetRessourceAccessRoles(user);
                if (roles.Any())
                {
                    if (string.IsNullOrEmpty(requirement.Permission))
                    {
                        context.Succeed(requirement);
                        return;
                    }

                    var permissions = requirement.Permission.Split(",").ToList();
                    var isAuthorized = roles.Any(r => permissions.Any(p => p.Trim() == r));
                    if (isAuthorized)
                    {
                        context.Succeed(requirement);
                        return;
                    }
                }

                context.Fail();
                throw new UnauthorizedException(SharedResources.AccessDeniedMessage, HttpStatusCode.Unauthorized);

            }
            catch (Exception ex)
            {
                throw new UnauthorizedException(ex.Message, HttpStatusCode.Unauthorized);
            }

        }

        public static IList<string> GetRessourceAccessRoles(UserInfoDto userInfo)
        {

            var roles = new List<string>();
            try
            {
                using (JsonDocument jd = JsonDocument.Parse(JsonSerializer.Serialize(userInfo.ResourceAccess)))
                {
                    var resourcesNamesRoot = JsonNode.Parse(jd.RootElement.GetRawText())?.AsObject();
                    if (resourcesNamesRoot != null)
                    {
                        string[] resourcesNames = resourcesNamesRoot.Select(p => p.Key).ToArray();
                        foreach (var resource in resourcesNames)
                        {
                            var userRoles = JsonSerializer.Deserialize<List<string>>(jd.RootElement.GetProperty(resource).GetProperty("roles").GetRawText());
                            if (userRoles != null) roles.AddRange(userRoles);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UnauthorizedException(ex.Message, HttpStatusCode.Unauthorized);
            }


            return roles;
        }
    }

    public class KcPermissionPolicyProvider : IAuthorizationPolicyProvider
    {

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return Task.FromResult(
                new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
        }

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        {
            return Task.FromResult<AuthorizationPolicy?>(null);
        }

        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {

            if (policyName.StartsWith(SharedResources.POLICY_PREFIX, StringComparison.OrdinalIgnoreCase))
            {
                var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                policy.AddRequirements(new KcPermissionRequirement(policyName[SharedResources.POLICY_PREFIX.Length..]));
                return Task.FromResult((AuthorizationPolicy?)policy.Build());
            }
            else
            {
                return Task.FromResult<AuthorizationPolicy?>(null);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class KcPermissionAttribute : AuthorizeAttribute
    {
        public KcPermissionAttribute(string requiredPermission = "")
        {
            RequiredPermission = requiredPermission;
        }

        public string? RequiredPermission
        {
            get
            {
                return Policy?[SharedResources.POLICY_PREFIX.Length..];
            }
            set
            {
                Policy = $"{SharedResources.POLICY_PREFIX}{value}";
            }
        }
    }
}
