using Microsoft.AspNetCore.Mvc;

namespace Server_Administration_Tool.Controllers
{
    public class AddAppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddApplication() 
        {
            return View();
        }

        public IActionResult AddNewApplication()
        {
            return View();
        }

        public IActionResult AddExistingApplication()
        {
            return View();
        }
    }
}
