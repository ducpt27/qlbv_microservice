using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class DriveScheduleDto : IMapFrom<DriveSchedule>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "user1")]
        public string User1 { get; set; }
        [JsonProperty(PropertyName = "user2")]
        public string User2 { get; set; }
        [JsonProperty(PropertyName = "route_id")]
        public int RouteId { get; set; }
        [JsonProperty(PropertyName = "car_id")]
        public int CarId { get; set; }
        [JsonProperty(PropertyName = "total_time")]
        public int TotalTime { get; set; }
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }
        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
        [JsonProperty(PropertyName = "total_chairs_remain")]
        public int TotalChairsRemain { get; set; }
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }
        [JsonProperty(PropertyName = "created_by")]
        public string CreatedBy { get; set; }
        [JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }
        [JsonProperty(PropertyName = "modified_by")]
        public string ModifiedBy { get; set; }
        [JsonProperty(PropertyName = "modified_on")]
        public string ModifiedOn { get; set; }
        
        [JsonProperty(PropertyName = "drive_point")]
        public IList<DrivePointDto> DrivePoints { get; set; }
        [JsonProperty(PropertyName = "drive_time")]
        public IList<DriveTimeDto> DriveTimes { get; set; }
        [JsonProperty(PropertyName = "chair_schedule")]
        public IList<ChairScheduleDto> ChairSchedules { get; set; }
        [JsonProperty(PropertyName = "car")]
        public CarDto Car { get; set; }
         
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DriveSchedule, DriveScheduleDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.CreatedOn,
                    opt => opt.MapFrom(src => ((DateTime)src.CreatedOn).ToString(CultureInfo.InvariantCulture)))
                .ForMember(x => x.ModifiedOn,
                    opt => opt.MapFrom(src => ((DateTime)src.ModifiedOn).ToString(CultureInfo.InvariantCulture)));
        }
    }
}