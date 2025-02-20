using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Common;
using Keycloak.AuthServices.Sdk;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Domain;
using Shared.Infrastructure.Permissions;

namespace Shared.Infrastructure.Configurations
{
    public static class KeycloakConfig
    {
        public static void AddKeycloakConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(configuration);

            var keycloakConfig = configuration.GetSection("Keycloak").Get<KeycloakAuthenticationOptions>() ?? throw new InvalidOperationException(SharedResources.KEYCLOACK_INVALID_CONFIG);
            services.AddKeycloakWebApiAuthentication(
                configuration,
                (options) =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Audience = keycloakConfig.Audience ?? throw new InvalidOperationException(SharedResources.KEYCLOACK_INVALID_AUDIENCE);
                }
            );

            services.AddKeycloakAuthorization(configuration);

            KeycloakAdminClientOptions adminClientOptions = new()
            {
                Realm = SharedSettings.kcRealm,
                AuthServerUrl = keycloakConfig.AuthServerUrl,
                SslRequired = keycloakConfig.SslRequired,
                Resource = keycloakConfig.Resource,
                VerifyTokenAudience = keycloakConfig.VerifyTokenAudience,
                Credentials = new KeycloakClientInstallationCredentials
                {
                    Secret = keycloakConfig.Credentials.Secret
                }
            };

            services.AddSingleton<IAuthorizationHandler, PermissionRequirementHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, KcPermissionPolicyProvider>();

            services.AddKeycloakAdminHttpClient(adminClientOptions);
        }
    }
}
