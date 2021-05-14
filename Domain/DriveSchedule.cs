using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("drive_schedule")]
    public class DriveSchedule : AuditableEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_1")]
        public string User1 { get; set; }
        [Column("user_2")]
        public string User2 { get; set; }
        [Column("route_id")]
        public int RouteId { get; set; }
        [Column("car_id")]
        public int CarId { get; set; }
        [Column("total_time")]
        public int TotalTime { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("note")]
        public string Note { get; set; }
        [Column("total_chairs_remain")]
        public int TotalChairsRemain { get; set; }
        [Column("status")]
        public int Status { get; set; }
        public IList<DrivePrice> DrivePrices { get; set; }
        public IList<DrivePoint> DrivePoints { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        public Car Car { get; set; }
    }
}