using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("order_item")]
    public class OrderItem
    {
        [Key] [Column("id")] public int Id { get; set; }
        [Column("order_id")] public int OrderId { get; set; }
        [Column("chair_id")] public int ChairId { get; set; }
        [Column("price")] public decimal Price { get; set; }
        [Column("discount")] public decimal Discount { get; set; }
        [Column("drive_schedule_id")] public int DriveScheduleId { get; set; }
        public Chair Chair { get; set; }

        public DriveSchedule DriveSchedule { get; set; }
    }
}