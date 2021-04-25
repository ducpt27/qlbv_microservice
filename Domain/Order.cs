using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("_order")]
    public class Order : AuditableEntity
    {
        [Key] [Column("id")] public int Id { get; set; }
        [Column("drive_schedule_id")] public int DriveScheduleId { get; set; }
        [Column("code")] public string Code { get; set; }
        [Column("price")] public decimal Price { get; set; }
        [Column("discount")] public decimal Discount { get; set; }
        [Column("mobile")] public string Mobile { get; set; }
        [Column("full_name")] public string FullName { get; set; }
        [Column("age")] public int Age { get; set; }
        [Column("status")] public int Status { get; set; }
        [Column("payment_status")] public int PaymentStatus { get; set; }
        [Column("drive_point_id_start")] public int DrivePointIdStart { get; set; }
        [Column("drive_point_id_end")] public int DrivePointIdEnd { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
    }
}