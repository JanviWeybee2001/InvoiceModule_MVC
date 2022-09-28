using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Invoice_Module.Data;

namespace Invoice_Module.Models
{
    public class AssignPartyModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please Select Party")]
        public int partyId { get; set; }

        [Required(ErrorMessage = "Please Select Product")]
        public int productId { get; set; }

        public string productName { get; set; }
        public Party Party { get; set; }
        public Product Product { get; set; }
    }
}
