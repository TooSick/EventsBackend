using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;

namespace Client.Controllers
{
    [Route("[controller]/[action]")]
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Time = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        public IActionResult Login()
        {
            return Redirect("https://localhost:10001/Auth/Login");
        }

        public IActionResult Events()
        {
            return Redirect("https://localhost:7265/swagger");
        }
    }
}
