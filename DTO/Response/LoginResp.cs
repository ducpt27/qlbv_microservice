using System.Text.Json.Serialization;

namespace VeXe.Dto.Response
{
    public class LoginResp
    {
        [JsonPropertyName("username")] public string UserName { get; set; }

        [JsonPropertyName("role")] public string Role { get; set; }

        [JsonPropertyName("access_token")] public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")] public string RefreshToken { get; set; }
    }
}