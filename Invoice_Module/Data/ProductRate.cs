using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Data
{
    public class ProductRate
    {
        public int id { get; set; }
        public int productId { get; set; }
        public Product Product { get; set; }
        public int Rate { get; set; }
        public DateTime DateOfRate { get; set; }
    }
}
