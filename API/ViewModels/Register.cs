using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.ViewModels
{
    public class Register
    {
        public int IdEmployee { get; set; }

        [Required(ErrorMessage = "NIP Employee is required")]
        public int NipEmployee { get; set; }

        [Required(ErrorMessage = "Name Employee is required")]
        public string NameEmployee { get; set; }

        [Required(ErrorMessage = "Name Employee is required")]
        public string GenderEmployee { get; set; }

        [Required(ErrorMessage = "Age Employee is required")]
        public int AgeEmployee { get; set; }

        [Required(ErrorMessage = "Status Employee is required")]
        public string StatusEmployee { get; set; }

        [Required(ErrorMessage = "Email Employee is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Usernamer is required")]
        [MinLength(5, ErrorMessage = "Usernamer cannot be less than 5 characters")]
        [StringLength(12)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password cannot be less than 8 characters")]
        [StringLength(12)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
