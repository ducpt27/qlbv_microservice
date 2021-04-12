using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    
    [Table("abcs")]
    public class Abc : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}