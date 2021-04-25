using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("point")]
    public class Point : AuditableEntity
    {
        [Key] public int Id { get; set; }

        [Column("name")] public string Name { get; set; }

        [Column("street")] public string Street { get; set; }

        [Column("province_id")] public int ProvinceId { get; set; }

        [Column("district_id")] public int DistrictId { get; set; }

        [Column("ward_id")] public int WardId { get; set; }

        [Column("status")] public int Status { get; set; }

        public IList<RoutePoint> RoutePoints { get; set; }
    }
}