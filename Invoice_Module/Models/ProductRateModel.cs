using Invoice_Module.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Models
{
    public class ProductRateModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please Select Product")]
        [Display(Name ="Product Name:")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Please add Rate of Product")]
        [Display(Name = "Product Rate:")]
        public int Rate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy}")]
        [Display(Name = "Date of Rate:")]
        public DateTime DateOfRate { get; set; }
    }
}
