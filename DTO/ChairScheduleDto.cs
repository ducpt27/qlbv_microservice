using System;
using System.Globalization;
using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class ChairScheduleDto: IMapFrom<ChairSchedule>
    {
        [JsonProperty(PropertyName ="id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName ="drive_schedule_id")]
        public int DriveScheduleId { get; set; }
        [JsonProperty(PropertyName ="chair_id")]
        public int ChairId { get; set; }
        [JsonProperty(PropertyName ="status")]
        public int Status { get; set; }
        [JsonProperty(PropertyName = "modified_by")]
        public string ModifiedBy { get; set; }
        [JsonProperty(PropertyName = "modified_on")]
        public string ModifiedOn { get; set; }
         
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChairSchedule, ChairScheduleDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.ModifiedOn,
                    opt => opt.MapFrom(src => ((DateTime)src.ModifiedOn).ToString(CultureInfo.InvariantCulture)));
        }
    }
}