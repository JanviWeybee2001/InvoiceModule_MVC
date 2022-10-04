using Invoice_Module.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoice_Module.Repository
{
    public interface IProductRepository
    {
        int addProduct(ProductModel model);
        Task<bool> DeleteProductAsync(int id, ProductModel productModel);
        Task<int> editProduct(int id, ProductModel model);
        Task<List<ProductModel>> GetAllProduct();
    }
}