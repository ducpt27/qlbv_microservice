using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;
using VeXe.DTO;

namespace VeXe.Dto.Request
{
    public class RouteReq : IRequest<RouteDto>
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