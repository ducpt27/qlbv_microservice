using System.Text.Json.Serialization;

namespace VeXe.DTO.Request
{
    public class ImpersonationRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}