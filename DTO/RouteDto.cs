﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class RouteDto : IMapFrom<Route>
    {
        public RouteDto()
        {
        }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "origin_id")]
        public int OriginId { get; set; }
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
        
        [JsonProperty(PropertyName = "route_points")]
        public IList<RoutePointDto> RoutePoints { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Route, RouteDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.CreatedOn,
                    opt => opt.MapFrom(src => ((DateTime)src.CreatedOn).ToShortDateString()))
                .ForMember(x => x.ModifiedOn,
                    opt => opt.MapFrom(src => ((DateTime)src.ModifiedOn).ToShortDateString()));
        }
    }
}