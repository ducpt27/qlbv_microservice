using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("drive_point")]
    public class DrivePoint
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("drive_schedule_id")]
        public int DriveScheduleId { get; set; }
        [Column("point_id")]
        public int PointId { get; set; }
        [Column("time_start")]
        public DateTime TimeStart { get; set; }
    }
}