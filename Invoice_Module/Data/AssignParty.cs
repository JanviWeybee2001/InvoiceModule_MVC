using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Data
{
    public class AssignParty
    {        
        public int id { get; set; }
        public int partyId { get; set; }
        public int productId { get; set; }

        public Party Party { get; set; }
        public Product Product { get; set; }
    }
}
