using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Module.Data
{
    public class InvoiceModuleContext : DbContext
    {
        public InvoiceModuleContext(DbContextOptions<InvoiceModuleContext> options)
            : base(options)
        {

        }
        public DbSet<Party> Party { get; set; }
        
        public DbSet<Product> Product { get; set; }

        public DbSet<AssignParty> AssignParty { get; set; }

        public DbSet<ProductRate> ProductRate { get; set; }

        public DbSet<Invoice> Invoice { get; set; }
        
    }
}
