using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }
       
        public async  Task<IActionResult> ProductIndex()
        {
            return View(await _productService.FindAllProducts());
        }

        public  IActionResult ProductCreate()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(model);
                if (response is not null)
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var product = await _productService.FindProductById(id);
            if(product is not null)
            {
                return View(product);
            }
            return NotFound();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(model);
                if (response is not null)
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }
        /**/
        [Authorize]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var product = await _productService.FindProductById(id);
            if (product is not null)
                return View(product);
            return NotFound();
        }
        
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
           
                var response = await _productService.DeleteProductById(model.Id);
            if (response)
                return RedirectToAction(nameof(ProductIndex));
            else
                return View(model);
            
           
        }
    }
}
