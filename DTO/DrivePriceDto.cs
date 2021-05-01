using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class DrivePriceDto: IMapFrom<DrivePrice>
    {
        [JsonProperty(PropertyName ="id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName ="drive_schedule_id")]
        public int DriveScheduleId { get; set; }
        [JsonProperty(PropertyName ="price")]
        public decimal Price { get; set; }
        [JsonProperty(PropertyName ="point_id_start")]
        public int PointIdStart { get; set; }
        [JsonProperty(PropertyName ="point_id_end")]
        public int PointIdEnd { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DrivePrice, DrivePriceDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}