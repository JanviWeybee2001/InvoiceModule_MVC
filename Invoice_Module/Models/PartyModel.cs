using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Invoice_Module.Models
{
    public class PartyModel
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Empty party is not valid")]
        [Display(Name = "Party Name: ")]
        public string partyName { get; set; }
    }
}
