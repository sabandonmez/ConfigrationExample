using ConfigrationExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace ConfigrationExample.Controllers
{
    public class HomeController : Controller
    {
        MailInfo _mailInfo;

        public HomeController(IOptions<MailInfo> mailInfo)
        {
            this._mailInfo = mailInfo.Value;
        }
        public IActionResult Index()
        {
            Console.WriteLine(_mailInfo.EmailInfo.Email);
            return View();
        }

        public IActionResult Privacy()
        {
            #region x
            
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