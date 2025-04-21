using System.Diagnostics;
using FTACADEMY_STUDENT_MANAGEMENT_APP.Models;
using Microsoft.AspNetCore.Mvc;

namespace FTACADEMY_STUDENT_MANAGEMENT_APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger; 
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard() 
        {
            ViewBag.Domain = _configuration["AppDomainName"];

            ViewBag.GoogleLogOutUrl = _configuration["BackendUrl"] + "/api/Auth/logout";
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
