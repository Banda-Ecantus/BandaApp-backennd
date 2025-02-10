using System.Text.Json.Serialization;

namespace Shared.Infrastructure.DTOS
{
    public class UserInfoDto
    {
        [JsonPropertyName("user_name")]
        public string? Username { get; set; }

        [JsonPropertyName("user_email")]
        public string? Email { get; set; }

        [JsonPropertyName("resource_access")]
        public dynamic? ResourceAccess { get; set; }

        [JsonPropertyName("sub")]
        public string? Sub { get; set; }
    }
}
