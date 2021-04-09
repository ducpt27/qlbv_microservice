using System.Text.Json.Serialization;

namespace VeXe.Config.Infrastructure
{
    public class JwtTokenConfig
    {
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        [JsonPropertyName("access_token_expiration")]
        public int AccessTokenExpiration { get; set; }

        [JsonPropertyName("refresh_token_expiration")]
        public int RefreshTokenExpiration { get; set; }
    }
}
