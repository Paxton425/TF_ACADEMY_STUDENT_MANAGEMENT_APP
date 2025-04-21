using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FTACADEMY_STUDENT_MANAGEMENT_APP.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            ViewBag.Domain = _configuration["AppDomainName"];

            ViewBag.GoogleLoginUrl = _configuration["BackendUrl"] + "/api/Auth/google/signin";

            return View();
        }

        [HttpGet]
        public IActionResult AuthVerification()
        {
            ViewBag.ApiUrl = _configuration["BackendUrl"];
            return View();
        }

        [HttpGet]
        public IActionResult SignOut() 
        {
            ViewBag.Domain = _configuration["AppDomainName"];

            ViewBag.GoogleLogOutConfirmationUrl = _configuration["BackendUrl"] + "/api/Auth/logoutconfirmation";
            ViewBag.GoogleLogOutUrl = _configuration["BackendUrl"] + "/api/Auth/logout";

            return View();
        }
    }
}
