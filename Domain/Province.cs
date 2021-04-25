using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("province")]
    public class Province
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        
        public IList<District> Districts { get; set; }
    }
}