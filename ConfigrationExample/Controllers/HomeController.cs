using ConfigrationExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ConfigrationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration )
        {
            this._configuration = configuration;
        }
        public IActionResult Index()
        {

            var connection = _configuration.GetConnectionString("SQL");
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connection);
            builder.UserID = _configuration["SQL:KullaniciAdi"]; 
            builder.Password = _configuration["SQL:Sifre"];

            var x = builder.ConnectionString;

            return View(); 
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