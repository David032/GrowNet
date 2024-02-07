using Microsoft.AspNetCore.Mvc;

namespace GrowNetWebApp.Controllers
{
    public class SoilSensorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
