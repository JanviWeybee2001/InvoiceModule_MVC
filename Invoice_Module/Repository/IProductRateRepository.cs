using Invoice_Module.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoice_Module.Repository
{
    public interface IProductRateRepository
    {
        Task<int> addProductRate(ProductRateModel productRateModel);
        Task<bool> deleteProductRate(int id, ProductRateModel productRateModel);
        Task<int> editProductRate(int id, ProductRateModel productRateModel);
        Task<List<ProductRateModel>> GetAllProdustRateItems();
    }
}