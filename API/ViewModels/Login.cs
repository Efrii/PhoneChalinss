using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.ViewModels
{
    public class Login
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Usernamer is required")]
        [MinLength(5, ErrorMessage = "Usernamer cannot be less than 5 characters")]
        [StringLength(12)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password cannot be less than 8 characters")]
        [StringLength(12)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<Role> Roles = new List<Role>();
    }
}
