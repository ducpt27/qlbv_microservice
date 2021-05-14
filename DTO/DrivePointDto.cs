using System.ComponentModel.DataAnnotations;
using System.Globalization;
using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class DriveTimeDto : IMapFrom<DrivePoint>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "drive_schedule_id")]
        public int DriveScheduleId { get; set; }
        [JsonProperty(PropertyName = "point_id")]
        [Required]
        public int PointId { get; set; }
        [JsonProperty(PropertyName = "time_start")]
        [Required]
        public string TimeStart { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DrivePoint, DriveTimeDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.TimeStart,
                    opt => opt.MapFrom(src => (src.TimeStart).ToString(CultureInfo.InvariantCulture)));
        }
    }
}