using AutoMapper;
using Newtonsoft.Json;
using VeXe.Domain;
using VeXe.Mapping;

namespace VeXe.DTO
{
    public class AbcDto : IMapFrom<Abc>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "created_by")]
        public string CreatedBy { get; set; }
        [JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }
        [JsonProperty(PropertyName = "modified_by")]
        public string ModifiedBy { get; set; }
        [JsonProperty(PropertyName = "modified_on")]
        public string ModifiedOn { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Abc, AbcDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}