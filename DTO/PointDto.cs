using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class PointDto : IMapFrom<Point>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "route_id")]
        public int RouteId { get; set; }
        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }
        [JsonProperty(PropertyName = "province_id")]
        public int ProvinceId { get; set; }
        [JsonProperty(PropertyName = "district_id")]
        public int DistrictId { get; set; }
        [JsonProperty(PropertyName = "ward_id")]
        public int WardId { get; set; }
        [JsonProperty(PropertyName = "position")]
        public int Position { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Point, PointDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}