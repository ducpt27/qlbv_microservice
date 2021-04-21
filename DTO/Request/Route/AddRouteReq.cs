using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace VeXe.DTO.Request.Route
{
    public class AddRouteReq : IRequest<RouteDto>
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("status")]
        public int Status { get; set; }
        
        [JsonPropertyName("origin_id")]
        public int OriginId { get; set; }
        
        public int[] PointIds  { get; set; }
    }
}