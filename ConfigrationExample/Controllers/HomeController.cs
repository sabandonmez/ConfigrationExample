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
            MailInfo mailInfo = _configuration.GetSection("MailInfo").Get<MailInfo>();

            return View();
        }

        public IActionResult Privacy()
        {
            #region x
            var v1 = _configuration["Ornek"];
            var v2 = _configuration["Person:Name"];

            var v7 = _configuration.GetSection("Person:Name");

            var v8 = _configuration.GetSection("Person").Get(typeof(Person));
            #endregion

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}