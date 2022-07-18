using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }

        [Required(ErrorMessage = "NIP Employee is required")]
        [StringLength(10)]
        [MinLength(3)]
        public int NipEmployee { get; set; }

        [Required(ErrorMessage = "Name Employee is required")]
        [MinLength(3)]
        public string NameEmployee { get; set; }

        [Required(ErrorMessage = "Name Employee is required")]
        [StringLength(1)]
        public string GenderEmployee { get; set; }

        [Required(ErrorMessage = "Age Employee is required")]
        public int AgeEmployee { get; set; }

        [Required(ErrorMessage = "Status Employee is required")]
        public string StatusEmployer { get; set; }
    }
}
