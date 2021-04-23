﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeXe.Common.Mapping;
using VeXe.Dto.Request;
using VeXe.DTO.Request.Route;

namespace VeXe.Domain
{
    [Table("route")]
    public class Route :AuditableEntity, IMapFrom<AddRouteReq>, IMapFrom<EditRouteReq>
    {
        [Key]
        public int Id { get; set; }
        
        [Column("origin_id")]
        public int OriginId { get; set; }
        
        public string Name { get; set; }
        
        public int Status { get; set; }
        
        public IList<RoutePoint> RoutePoints { get; set; }
        
    }
    
    
}