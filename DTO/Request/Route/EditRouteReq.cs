using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace VeXe.DTO.Request.Route
{
    public class EditRouteReq : IRequest<RouteDto>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        public int Id { get; set; }
        
        [JsonPropertyName("status")]
        public int Status { get; set; }
        
        [JsonPropertyName("origin_id")]
        public int OriginId { get; set; }
    }
}