using Invoice_Module.Models;
using Invoice_Module.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IAssignPartyRepository _assignPartyRepository = null;

        public InvoiceController(IInvoiceRepository invoiceRepository, IAssignPartyRepository assignPartyRepository)
        {
            _invoiceRepository = invoiceRepository;
            _assignPartyRepository = assignPartyRepository;
        }

        public async Task<IActionResult> Invoice(int id, bool isAdded = false, int grandTotal = 0, bool isSuccess = false, bool isFailed = false)
        {
            if (isAdded)
            {
                ViewBag.Invoice = await _invoiceRepository.GetAllInvoice();
                ViewBag.display = true;
                ViewBag.IsSuccess = isSuccess;
                ViewBag.IsFailed = false;
                ViewBag.grandTotal = grandTotal;
                return View();
            }
            ViewBag.display = false;
            ViewBag.IsFailed = isFailed;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Invoice(int Id, InvoiceModel invoiceModel)
        {
            int grandTotal = 0;
            if (ModelState.IsValid)
            {
                grandTotal = await _invoiceRepository.InvoiceAdd(invoiceModel);
                return RedirectToAction(nameof(Invoice), new { isAdded = true, grandTotal = grandTotal, isSuccess = true });
            };
            return RedirectToAction(nameof(Invoice), new { isAdded = false, grandTotal = grandTotal, isFailed = true });
        }

        public IActionResult InvoiceClose(bool isAdded = false)
        {
            return RedirectToAction(nameof(Invoice), new { isAdded = false });
        }

        [HttpGet]
        public async Task<JsonResult> BindProductDetails(int PartyId)
        {
            var productDetails = await _invoiceRepository.BindProduct(PartyId);

            return Json(productDetails);
        }

        [HttpGet]
        public async Task<JsonResult> BindRateDetails(int ProductId)
        {
            int rate = await _invoiceRepository.BindRate(ProductId);

            return Json(rate);
        }

        public async Task<IActionResult> ClrearInvoice()
        {
            await _invoiceRepository.ClrearInvoiceAsync();

            return RedirectToAction(nameof(Invoice), new { isAdded = false });
        }
    }
}
