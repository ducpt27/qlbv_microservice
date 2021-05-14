using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class RoutePointDto : IMapFrom<RoutePoint>
    {
        [JsonProperty(PropertyName = "route_id")]
        public int RouteId { get; set; }
        [JsonProperty(PropertyName = "point_id")]
        public int PointId { get; set; }

        [JsonProperty(PropertyName = "position")]
        public int Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RoutePoint, RoutePointDto>()
                .ForMember(d => d.PointId, opt => opt.MapFrom(s => s.PointId));
        }
    }
}