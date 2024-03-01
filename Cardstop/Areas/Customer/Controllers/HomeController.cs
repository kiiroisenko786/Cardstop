using Cardstop.DataAccess.Repository.iRepository;
using Cardstop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cardstop.Controllers
{
    // To tell the controller that it belongs to a specific area
    // we use the Area attribute tag
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly iUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, iUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };
            return View(cart);
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