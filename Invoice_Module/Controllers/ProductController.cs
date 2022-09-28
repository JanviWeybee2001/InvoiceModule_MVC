using Invoice_Module.Models;
using Invoice_Module.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository = null;

        public ProductController(ProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        [Route("~/AllProduct")]
        public async Task<IActionResult> allProductItem()
        {
            var data = await productRepository.GetAllProduct();
            return View(data);
        }

        public ViewResult addProduct(bool isSuccess = false, bool isFailed = false)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.IsFailed = isFailed;
            return View();
        }

        [HttpPost]
        public IActionResult addProduct(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                int id = productRepository.addProduct(model);
                if (id > 0)
                {
                    return RedirectToAction(nameof(addProduct), new { isSuccess = true });
                }
                else
                {
                    return RedirectToAction(nameof(addProduct), new { isFailed = true });
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id, ProductModel productModel)
        {
            bool isDeleted = await productRepository.DeleteProductAsync(id, productModel);
            if (isDeleted)
            {
                return RedirectToAction("allProductItem");
            }
            return null;
        }

        [HttpGet("editProduct/{id}/{productName}")]
        public IActionResult editProduct(string productName, bool isSuccess = false, [FromRoute] int id = 0)
        {
            return View();
        }

        [HttpPost("editProduct/{id}/{productName}")]
        public async Task<IActionResult> editProduct([FromRoute] int id, ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                await productRepository.editProduct(id, productModel);
            }
            return RedirectToAction("allProductItem");
        }
    }
}
