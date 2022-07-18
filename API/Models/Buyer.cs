using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Buyer
    {
        [Key]
        public int IdBuyer { get; set; }

        [Required(ErrorMessage = "Name Buyer is required")]
        [Display(Name = "Name Buyer")]
        public string NameBuyer { get; set; }

        [Required(ErrorMessage = "Gender Buyer is required")]
        [StringLength(1)]
        [Display(Name = "Gender Buyer")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone Buyer is required")]
        [StringLength(12, ErrorMessage = "Phone Number cannot be longer than 12 characters.")]
        [Display(Name = "Phone Buyer")]
        public string Phone { get; set; }
    }
}
