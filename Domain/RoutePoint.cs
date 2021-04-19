using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("route_point")]
    public class RoutePoint
    {
        [Column("route_id")]
        public int RouteId { get; set; }
        [Column("point_id")]
        public int PointId { get; set; }
        
        public Point Point { get; set; }
        
        public Route Route { get; set; }
        
        public int Position { get; set; }
    }
}