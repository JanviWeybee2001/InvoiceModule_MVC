using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Module.Data;
using Invoice_Module.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Module.Repository
{
    public class InvoiceRepository
    {
        private readonly InvoiceModuleContext _context = null;

        public InvoiceRepository(InvoiceModuleContext context)
        {
            _context = context;
        }

        public async Task<List<InvoiceModel>> GetAllInvoice()
        {
            return await _context.Invoice
                  .Select(invoice => new InvoiceModel()
                  {
                      Id = invoice.Id,
                      PartyId = invoice.PartyId,
                      PartyName = _context.Party.Where(x => x.id == invoice.PartyId).FirstOrDefault().partyName,
                      ProductId = invoice.ProductId,
                      ProductName = _context.Product.Where(x => x.id == invoice.ProductId).FirstOrDefault().productName,
                      CurrentRate = invoice.CurrentRate,
                      Quantity = invoice.Quantity,
                      Total = invoice.Total
                  }).ToListAsync();
        }

        public async Task<int> InvoiceAdd(InvoiceModel invoiceModel)
        {
            var y = _context.Invoice
                    .Where(x => x.PartyId == invoiceModel.PartyId).Where(x => x.ProductId == invoiceModel.ProductId).Where(x => x.CurrentRate == invoiceModel.CurrentRate).FirstOrDefault();

            if (y == null)
            {
                var newInvoice = new Invoice()
                {
                    PartyId = invoiceModel.PartyId,
                    ProductId = invoiceModel.ProductId,
                    CurrentRate = invoiceModel.CurrentRate,
                    Quantity = invoiceModel.Quantity,
                    Total = invoiceModel.CurrentRate * invoiceModel.Quantity
                };
                await _context.Invoice.AddAsync(newInvoice);
            }
            else
            {
                y.PartyId = invoiceModel.PartyId;
                y.ProductId = invoiceModel.ProductId;
                y.CurrentRate = invoiceModel.CurrentRate;
                y.Quantity = y.Quantity + invoiceModel.Quantity;
                y.Total = invoiceModel.CurrentRate * y.Quantity;
            }

            await _context.SaveChangesAsync();

            int grandTotal = (from i in _context.Invoice select i.Total).Sum();

            return grandTotal;
        }

        public async Task<List<AssignPartyModel>> BindProduct(int PartyId)
        {
            return await _context.AssignParty.Where(x => x.partyId == PartyId)
                .Select(product => new AssignPartyModel()
                {
                    productId = product.productId,
                    productName = product.Product.productName
                }).Distinct().ToListAsync();
        }

        public async Task<int> BindRate(int ProductId)
        {
            return await _context.ProductRate.Where(x => x.productId == ProductId)
                .Select(x => x.Rate).FirstOrDefaultAsync();
        }

        public async Task ClrearInvoiceAsync()
        {
            foreach (var item in _context.Invoice)
            {
                _context.Invoice.Remove(item);
            }
            _context.SaveChanges();
        }
    }
}
