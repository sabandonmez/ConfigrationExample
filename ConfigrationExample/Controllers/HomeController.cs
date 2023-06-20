using ConfigrationExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConfigrationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var v1 = _configuration["Ornek"];
            var v2 = _configuration["Person:Name"];

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}