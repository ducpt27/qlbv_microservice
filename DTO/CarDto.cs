using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class CarDto : IMapFrom<Car>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "origin_id")]
        public int OriginId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "total_chairs")]
        public int TotalChairs { get; set; }
        [JsonProperty(PropertyName = "total_floors")]
        public int TotalFloors { get; set; }
        [JsonProperty(PropertyName = "total_rows")]
        public int TotalRows { get; set; }
        [JsonProperty(PropertyName = "total_cols")]
        public int TotalCols { get; set; }
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
            profile.CreateMap<Car, CarDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}