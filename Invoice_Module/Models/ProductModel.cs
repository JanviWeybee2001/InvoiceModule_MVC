using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Invoice_Module.Models
{
    public class ProductModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Empty Product is not valid")]
        [Display(Name ="Product Name : ")]
        public string productName { get; set; }
    }
}
