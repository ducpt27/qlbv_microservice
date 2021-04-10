using System.Text.Json.Serialization;

namespace VeXe.Dto.Request
{
    public class ImpersonationRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}