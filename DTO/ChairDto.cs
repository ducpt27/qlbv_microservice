using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class ChairDto : IMapFrom<Chair>
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
        [JsonProperty(PropertyName = "car_id")]
        public int? CarId { get; set; }
        [JsonProperty(PropertyName = "row")]
        public int Row { get; set; } 
        [JsonProperty(PropertyName = "col")]
        public int Col { get; set; } 
        [JsonProperty(PropertyName = "floor")]
        public int Floor { get; set; } 
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Chair, ChairDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}