using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("chair")]
    public class Chair
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("car_id")]
        public int CarId { get; set; }
        [Column("row")]
        public int Row { get; set; } 
        [Column("col")]
        public int Col { get; set; } 
        [Column("floor")]
        public int Floor { get; set; }
        public Car Car { get; set; }
    }
}