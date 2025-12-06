using System.Diagnostics;
using Batch25JenkinsPipeline.Models;
using Batch25JenkinsPipeline.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch25JenkinsPipeline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product(1, "Laptop", 999.99m, "Electronics", true),
                new Product(2, "Smartphone", 699.99m, "Electronics", true),
                new Product(3, "Desk Chair", 249.99m, "Furniture", true),
                new Product(4, "Coffee Mug", 12.99m, "Home & Kitchen", false),
                new Product(5, "Wireless Headphones", 149.99m, "Electronics", true),
                new Product(6, "Notebook", 8.99m, "Office Supplies", true),
                new Product(7, "Desk Lamp", 34.99m, "Home & Kitchen", true),
                new Product(8, "Backpack", 59.99m, "Accessories", true)
            };
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
