using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Middleware;
public class KeycloackAuthenticationMiddleware(RequestDelegate next, HttpClient httpClient, IConfiguration configuration, ILogger<KeycloackAuthenticationMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly HttpClient _httpClient = httpClient;
    private readonly IConfiguration _configuration = configuration;
    private readonly ILogger<KeycloackAuthenticationMiddleware> _logger = logger;
    private string? _accessToken;
        private string? _refreshToken;

    public async Task InvokeAsync(HttpContext context)
    {
        if (string.IsNullOrEmpty(_accessToken) || TokenExpired(_accessToken))
        {
            await RefreshTokenAsync();
        }
        _logger.LogInformation("Access Token: {AccessToken}", _accessToken);

        context.Request.Headers["Authorization"] = $"{_accessToken}";

        await _next(context);
    }

    private static bool TokenExpired(string token)
    {
        var jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
        if (jwtToken == null)
        {
            throw new ArgumentException("Invalid JWT token");
        }

        var expClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp);
        if (expClaim == null)
        {
            throw new ArgumentException("JWT token does not contain 'exp' claim");
        }

        var exp = long.Parse(expClaim.Value);
        var expirationTime = DateTimeOffset.FromUnixTimeSeconds(exp).UtcDateTime;

        return expirationTime < DateTime.UtcNow;
    }

    private async Task RefreshTokenAsync()
    {
        var tokenEndpoint = $"{_configuration["Keycloak:AuthUrl"]}/realms/{_configuration["Keycloak:Realm"]}/protocol/openid-connect/token";
        var clientId = _configuration["Keycloak:ClientId"];
        var clientSecret = _configuration["Keycloak:ClientSecret"];

        var requestBody = new StringContent($"client_id={clientId}&client_secret={clientSecret}&grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

        var response = await _httpClient.PostAsync(tokenEndpoint, requestBody);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseContent);
            _accessToken = tokenResponse?.AccessToken;
            _refreshToken = tokenResponse?.RefreshToken;
        }
        else
        {
            _logger.LogError("Failed to refresh token. Status code: {StatusCode}", response.StatusCode);
            throw new ApplicationException("Failed to refresh token");
        }
    }
}

public class TokenResponse
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }
}
