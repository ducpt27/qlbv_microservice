using System.Text.Json.Serialization;

namespace VeXe.Dto.Request
{
    public class RefreshTokenReq
    {
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}