using dbdeneme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace dbdeneme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Ana sayfa
        public IActionResult Index()
        {
            return View();
        }

        // Gizlilik sayfasý
        public IActionResult Privacy()
        {
            return View();
        }

        // Hata sayfasý
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
