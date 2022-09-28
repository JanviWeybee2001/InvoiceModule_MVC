using Invoice_Module.Models;
using Invoice_Module.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Controllers
{
    public class ProductRateController : Controller
    {
        private readonly ProductRateRepository productRateRepository = null;

        public ProductRateController(ProductRateRepository _productRateRepository)
        {
            productRateRepository = _productRateRepository;
        }

        public async Task<IActionResult> allProductRateItem()
        {
            var data = await productRateRepository.GetAllProdustRateItems();
            return View(data);
        }

        public IActionResult addProductRate(bool isSuccess = false, bool isFailed = false)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.IsFailed = isFailed;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> addProductRate(ProductRateModel productRateModel)
        {
            if (ModelState.IsValid)
            {
                var id = await productRateRepository.addProductRate(productRateModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(addProductRate), new { isSuccess = true });
                }
                else
                {
                    return RedirectToAction(nameof(addProductRate), new { isFailed = true });
                }
            }
            return View();
        }

        [HttpGet("EditProductRate/{id}/{productId}/{rate}")]
        public IActionResult editProductRate(int productId, int rate, int isSuccess = 0, [FromRoute] int productRateId = 0)
        {
            return View();
        }

        [HttpPost("EditProductRate/{id}/{productId}/{rate}")]
        public async Task<IActionResult> editProductRate([FromRoute] int id, ProductRateModel productRateModel)
        {
            if (ModelState.IsValid)
            {
                await productRateRepository.editProductRate(id, productRateModel);
            }
            return RedirectToAction("allProductRateItem");
        }

        public async Task<IActionResult> deleteProductRate(int id, ProductRateModel productRateModel)
        {
            bool isDeleted = await productRateRepository.deleteProductRate(id, productRateModel);
            if (isDeleted)
            {
                return RedirectToAction("allProductRateItem");
            }
            return null;
        }

    }
}
