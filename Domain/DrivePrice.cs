using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("drive_price")]
    public class DrivePrice
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("drive_schedule_id")]
        public int DriveScheduleId { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("point_id_start")]
        public int PointIdStart { get; set; }
        [Column("point_id_end")]
        public int PointIdEnd { get; set; }
    }
}