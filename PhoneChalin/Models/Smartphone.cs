using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneChalin.Models
{
    public class Smartphone
    {
        [Key]
        public int IdSmartphone { get; set; }

        [ForeignKey("supplierModel")]
        public int IdSupplier { get; set; }
        public Supplier supplierModel { get; set; }

        [Required(ErrorMessage = "Name Smartphone is required")]
        [Display(Name = "Name Smartphone")]
        public string NameSmartphone { get; set; }

        [Required(ErrorMessage = "Price Smartphone is required")]
        [Display(Name = "Price Smartphone")]
        public int PriceSmartphone { get; set; }

        [Required(ErrorMessage = "Stock Smartphone is required")]
        [Display(Name = "Stock Smartphone")]
        public int StockSmartphoen { get; set; }
    }
}
