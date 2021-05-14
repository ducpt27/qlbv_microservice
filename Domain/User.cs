using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeXe.Domain
{
    [Table("user")]
    public class User : AuditableEntity
    {
        [Key] [Column("id")] public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Column("full_name")] public string FullName { get; set; }
        public string Mobile { get; set; }
        public int Age { get; set; }
        public string Note { get; set; }
        [Column("group_id")] public int GroupId { get; set; }
        public DateTime BirthDate { get; set; }
        public int Status { get; set; }
    }
}
