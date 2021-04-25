using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("car")]
    public class Car :AuditableEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("origin_id")]
        public int OriginId { get; set; }
        
        public string Name { get; set; }
        
        [Column("total_chairs")]
        public int TotalChairs { get; set; }
        
        [Column("total_floors")]
        public int TotalFloors { get; set; }
        
        [Column("total_rows")]
        public int TotalRows { get; set; }
        
        [Column("total_cols")]
        public int TotalCols { get; set; }

        [Column("note")]
        public string Note { get; set; }
        
        [Column("status")]
        public int Status { get; set; }
        
        public IList<Chair> Chairs { get; set; }
        
        public IList<DriveSchedule> DriveSchedules { get; set; }
    }
}