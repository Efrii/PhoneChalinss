﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneChalin.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }

        [Required(ErrorMessage = "Role Employee is required")]
        public string RoleEmployee { get; set; }

        //public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
