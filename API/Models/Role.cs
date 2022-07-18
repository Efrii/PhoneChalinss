using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }

        [Required(ErrorMessage = "Role Employee is required")]
        public string RoleEmployee { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

    }
}
