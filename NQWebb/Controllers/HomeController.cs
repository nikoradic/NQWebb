using Microsoft.AspNetCore.Mvc;
using NQWebb.Helpers.Services;
using NQWebb.Models.ViewModels;

namespace NQWebb.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {

        var tags = new List<string> { "New", "Popular", "Featured" };
        var colletion = new List<CollectionVM>();
        foreach (var tag in tags)
        {
            var products = await _productService.GetAllByTagNameAsync(tag);
            var vM = new CollectionVM { Items = products, Title = tag };
            colletion.Add(vM);
        }

        var viewModel = new HomeVM { Collection = colletion };


        return View(viewModel);

        //var viewModel = new HomeVM
        //{
        //    BestCollection = new CollectionVM
        //    {
        //        Title = "Best Collection",
        //        Items = await _productService.GetAllByTagNameAsync("New")
        //    }



        //};
    }
}



