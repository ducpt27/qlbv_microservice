using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{

    public class ProvinceDto : IMapFrom<Province>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        public IList<DistrictDto> Districts { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Province, ProvinceDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}