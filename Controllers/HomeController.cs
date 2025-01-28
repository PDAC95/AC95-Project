using Microsoft.AspNetCore.Mvc;
using MultiLanguages.Models;
using System.Diagnostics;
using System.Globalization;

namespace MultiLanguages.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult HowWeWork()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Web()
        {
            return View();
        }

        public IActionResult Ecommerce()
        {
            return View();
        }

        public IActionResult App()
        {
            return View();
        }

        public IActionResult Software()
        {
            return View();
        }

        public IActionResult AI()
        {
            return View();
        }

        public IActionResult Monthly()
        {
            return View();
        }

        public IActionResult Monthlyweb()
        {
            return View();
        }

        public IActionResult Monthlyecommerce()
        {
            return View();
        }

        public IActionResult Monthlyapp()
        {
            return View();
        }

        public IActionResult Monthlysoftware()
        {
            return View();
        }

        public IActionResult Team()
        {
            return View();
        }

        public IActionResult Teammonth()
        {
            return View();
        }

        public IActionResult Teamproject()
        {
            return View();
        }

        public IActionResult Teamsprint()
        {
            return View();
        }

        public IActionResult Brand()
        {
            return View();
        }

        public IActionResult Design()
        {
            return View();
        }

        public IActionResult Marketing()
        {
            return View();
        }

        public IActionResult Monthlydesign()
        {
            return View();
        }

        public IActionResult Monthlymarketing()
        {
            return View();
        }
        public IActionResult Newsletter()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult Cookies()
        {
            return View();
        }

        public IActionResult Careers()
        {
            return View();
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult Started()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ChangeLanguage(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                lang = "en";
            }
            Response.Cookies.Append("Language", lang);
            return Redirect(Request.GetTypedHeaders().Referer.ToString());
        }
    }
}
