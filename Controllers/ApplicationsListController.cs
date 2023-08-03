using Microsoft.AspNetCore.Mvc;

namespace Server_Administration_Tool.Controllers
{
    public class ApplicationsListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ApplicationsList()
        {
            return View();
        }
    }
}
