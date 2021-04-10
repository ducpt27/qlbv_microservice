using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VeXe.Dto.Request
{
    public class LoginReq
    {
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}