using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneChalin.ViewModels
{
    public class RoleVM
    {
        [Required(ErrorMessage = "Role Employee is required")]
        public string RoleEmployee { get; set; }
    }
}
