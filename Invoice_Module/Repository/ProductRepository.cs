using Invoice_Module.Data;
using Invoice_Module.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly InvoiceModuleContext _context = null;

        public ProductRepository(InvoiceModuleContext context)
        {
            _context = context;
        }

        public int addProduct(ProductModel model)
        {
            var y = _context.Product
                   .Where(x => x.productName == model.productName).FirstOrDefault();

            if (y == null)
            {
                var newProduct = new Product()
                {
                    productName = model.productName
                };

                _context.Product.Add(newProduct);
                _context.SaveChanges();

                return newProduct.id;
            }
            return 0;
        }

        public async Task<List<ProductModel>> GetAllProduct()
        {
            var products = new List<ProductModel>();
            var allproducts = await _context.Product.ToListAsync();
            if (allproducts?.Any() == true)
            {
                foreach (var product in allproducts)
                {
                    products.Add(new ProductModel()
                    {
                        id = product.id,
                        productName = product.productName
                    });
                }
            }
            return products;
        }

        public async Task<bool> DeleteProductAsync(int id, ProductModel productModel)
        {
            var check1 = _context.AssignParty.Where(x => x.productId == productModel.id).FirstOrDefault();
            var check2 = _context.ProductRate.Where(x => x.productId == productModel.id).FirstOrDefault();
            var checkInvoice = _context.Invoice.Where(x => x.ProductId == id).ToList();
            if (check1 == null && check2 == null)
            {
                if (id == productModel.id)
                {
                    var product = new Product()
                    {
                        id = id
                    };
                    _context.Product.Remove(product);
                }
                if (checkInvoice != null)
                {
                    _context.Invoice.RemoveRange(checkInvoice);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<int> editProduct(int id, ProductModel model)
        {
            var y = _context.Product
                   .Where(x => x.productName == model.productName && x.id != id).FirstOrDefault();

            if (y == null)
            {
                var newProduct = new Product()
                {
                    id = id,
                    productName = model.productName
                };
                _context.Product.Update(newProduct);
                await _context.SaveChangesAsync();
                return id;
            }
            return 0;
        }

    }
}


//public List<ProductModel> product()
//{
//    return new List<ProductModel>()
//            {
//                new ProductModel(){ id=1, productName="Innova Crysta"},
//                new ProductModel(){ id=2, productName="Fortuner"},
//                new ProductModel(){ id=3, productName="The Mustang"},
//                new ProductModel(){ id=4, productName="Figo"},
//                new ProductModel(){ id=5, productName="Rolls-Royce"},
//                new ProductModel(){ id=6, productName="BMW Motorrad"},
//                new ProductModel(){ id=7, productName="Milkybar"},
//                new ProductModel(){ id=8, productName="Dairy milk"},
//                new ProductModel(){ id=9, productName="Silk"},
//                new ProductModel(){ id=10, productName="Tang"}
//            };
//}