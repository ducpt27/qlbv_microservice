using System.Text.Json.Serialization;

namespace VeXe.DTO.Request
{
    public class RefreshTokenReq
    {
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}