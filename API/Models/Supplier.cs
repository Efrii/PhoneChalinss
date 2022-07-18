using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Supplier
    {
        [Key]
        public int IdSupplier { get; set; }

        [Required(ErrorMessage = "Brand Supplier is required")]
        [Display(Name = "Brand Supplier")]
        public string BrandSupplier { get; set; }

        [Required(ErrorMessage = "Name Supplier is required")]
        [Display(Name = "Name Supplier")]
        [MaxLength(25)]
        [MinLength(3)]
        public string NameSupplier { get; set; }

        [Required(ErrorMessage = "Phone Supplier is required")]
        [StringLength(12)]
        [MaxLength(12)]
        [MinLength(11, ErrorMessage = "Phone Number cannot be less than 11 characters.")]
        [Display(Name = "Phone Supplier")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address Supplier")]
        public string Address { get; set; }
    }
}
