using Microsoft.AspNetCore.Mvc;

namespace Jobless.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NotEnough()
        {
            return View();
        }
    }
}