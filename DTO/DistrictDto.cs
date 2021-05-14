using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class DistrictDto : IMapFrom<District>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "prefix")]
        public string Prefix { get; set; }
        [JsonProperty(PropertyName = "province_id")]
        public int ProvinceId { get; set; }

        //public IList<WardDto> Wards { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<District, DistrictDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}