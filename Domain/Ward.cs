using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("ward")]
    public class Ward
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        [Column("province_id")]
        public int ProvinceId { get; set; }
        [Column("district_id")]
        public int DistrictId { get; set; }
        public District District { get; set; }
    
    }
}