using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Data
{
    public class Invoice
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int ProductId { get; set; }
        public int CurrentRate { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
