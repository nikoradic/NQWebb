using Microsoft.AspNetCore.Mvc;
using NQWebb.Helpers.Services;
using NQWebb.Models.ViewModels;

namespace NQWebb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Details(string articleNumber)
        {
            var item = await _productService.GetAsync(articleNumber);
            return View(item);
        }


        public async Task<IActionResult> Index()
        {
            var vM = new CollectionVM
            {

                Items = await _productService.GetAllAsync()
            };
            return View(vM);
        }


        public async Task<IActionResult> NewCollection()
        {
            var vM = new NewCollectionVM
            {
                Title = "New Collection",
                Items = await _productService.GetNewCollectionAsync()
            };
            return View(vM);
        }
    }
}
