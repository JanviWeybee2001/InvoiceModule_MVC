using Invoice_Module.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoice_Module.Repository
{
    public interface IInvoiceRepository
    {
        Task<List<AssignPartyModel>> BindProduct(int PartyId);
        Task<int> BindRate(int ProductId);
        Task ClrearInvoiceAsync();
        Task<List<InvoiceModel>> GetAllInvoice();
        Task<int> InvoiceAdd(InvoiceModel invoiceModel);
    }
}