using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    public abstract class AuditableEntity
    {
        [Column("created_by")] public string CreatedBy { get; set; }

        [Column("created_on")] public DateTime CreatedOn { get; set; }
        [Column("modified_by")] public string ModifiedBy { get; set; }
        [Column("modified_on")] public DateTime ModifiedOn { get; set; }
    }
}