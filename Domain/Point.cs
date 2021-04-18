using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("point")]
    public class Point
    {
        [Key]
        public int Id { get; set; }
        [Column("route_id")]
        public int RouteId { get; set; }
        
        public string Street { get; set; }
        
        [Column("province_id")]
        public int ProvinceId { get; set; }
        
        [Column("district_id")]
        public int DistrictId { get; set; }
        
        [Column("ward_id")]
        public int WardId { get; set; }
        
        public int Position { get; set; }
        
        public virtual ICollection<Route> Routes { get; set; }
        
    }
}