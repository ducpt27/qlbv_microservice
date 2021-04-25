using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeXe.DTO;

namespace VeXe.Domain
{
    [Table("district")]
    public class District
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        [Column("province_id")]
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        
        public IList<Ward> Wards { get; set; }
    }
}