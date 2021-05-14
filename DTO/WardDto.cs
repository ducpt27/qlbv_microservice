using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class WardDto : IMapFrom<Ward>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "prefix")]
        public string Prefix { get; set; }
        [JsonProperty(PropertyName = "province_id")]
        public int ProvinceId { get; set; }
        [JsonProperty(PropertyName = "district_id")]
        public int DistrictId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Ward, WardDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}