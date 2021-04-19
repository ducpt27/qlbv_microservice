using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("car")]
    public class Car :AuditableEntity
    {
        [Key]
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

        public string Note { get; set; }
        
    }
}