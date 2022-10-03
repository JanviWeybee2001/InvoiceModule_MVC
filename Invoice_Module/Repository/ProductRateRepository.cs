using Invoice_Module.Data;
using Invoice_Module.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Repository
{
    public class ProductRateRepository
    {
        private readonly InvoiceModuleContext _context = null;

        public ProductRateRepository(InvoiceModuleContext context)
        {
            _context = context;
        }

        public async Task<List<ProductRateModel>> GetAllProdustRateItems()
        {
            return await _context.ProductRate
                  .Select(productRate => new ProductRateModel()
                  {
                      id = productRate.id,
                      ProductId = productRate.productId,
                      Product = productRate.Product,
                      Rate = productRate.Rate,
                      DateOfRate = productRate.DateOfRate
                  }).ToListAsync();
        }

        public async Task<int> addProductRate(ProductRateModel productRateModel)
        {
            var y = _context.ProductRate
                    .Where(x => x.productId == productRateModel.ProductId).FirstOrDefault();

            if (y == null)
            {
                var productRate = new ProductRate()
                {
                    productId = productRateModel.ProductId,
                    Rate = productRateModel.Rate,
                    DateOfRate = productRateModel.DateOfRate
                };

                await _context.ProductRate.AddAsync(productRate);
                await _context.SaveChangesAsync();

                var product = await _context.Product.FindAsync(productRateModel.ProductId);

                return productRate.id;
            }
            return 0;
        }

        public async Task<int> editProductRate(int id, ProductRateModel productRateModel)
        {
            var y = _context.ProductRate
                    .Where(x => x.productId == productRateModel.ProductId && x.id!=id).FirstOrDefault();

            if (y == null)
            {
                var productRate = new ProductRate()
                {
                    id = id,
                    productId = productRateModel.ProductId,
                    Rate = productRateModel.Rate,
                    DateOfRate = productRateModel.DateOfRate
                };

                _context.ProductRate.Update(productRate);
                await _context.SaveChangesAsync();
                return productRate.id;
            }
            else
            {
                return 0;
            }

        }

        public async Task<bool> deleteProductRate(int id, ProductRateModel productRateModel)
        {
            if (id == productRateModel.id)
            {
                var productRate = new ProductRate()
                {
                    id = id
                };
                _context.ProductRate.Remove(productRate);
            }
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
