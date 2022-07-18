using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class UserRole
    {
        [Key]
        public int IdUserRole { get; set; }

        [ForeignKey("User")]
        public int IdUser { get; set; }
        public User User { get; set; }

        [ForeignKey("Role")]
        public int IdRole { get; set; }
        public Role Role { get; set; }
    }
}
