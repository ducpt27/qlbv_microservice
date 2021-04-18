using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VeXe.DTO;

namespace VeXe.Dto.Request
{
    public class RouteReq
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("status")]
        public int Status { get; set; }
        
        [JsonPropertyName("origin_id")]
        public int OriginId { get; set; }
        
        [JsonPropertyName("points")]
        public List<PointDto> Points  { get; set; }
    }
}