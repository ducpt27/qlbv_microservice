using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("chair_schedule")]
    public class ChairSchedule : ModifiedEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("drive_schedule_id")]
        public int DriveScheduleId { get; set; }
        [Column("chair_id")]
        public int ChairId { get; set; }
        [Column("status")]
        public int Status { get; set; }
    }
}