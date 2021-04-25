﻿using System;
using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class DriveTimeDto: IMapFrom<DriveTime>
    {
        [JsonProperty(PropertyName ="id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName ="drive_schedule_id")]
        public int DriveScheduleId { get; set; }
        [JsonProperty(PropertyName ="point_id")]
        public int PointId { get; set; }
        [JsonProperty(PropertyName ="time_start")]
        public string TimeStart { get; set; }
         
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DriveTime, DriveTimeDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.TimeStart,
                    opt => opt.MapFrom(src => ((DateTime)src.TimeStart).ToString()));
        }
    }
}