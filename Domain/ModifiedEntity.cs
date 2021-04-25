using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    public abstract class ModifiedEntity
    {
        [Column("modified_by")] public string ModifiedBy { get; set; }
        [Column("modified_on")] public DateTime? ModifiedOn { get; set; }
    }
}