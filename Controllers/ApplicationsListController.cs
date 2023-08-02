using Microsoft.AspNetCore.Mvc;

namespace Server_Administration_Tool.Controllers
{
    public class ApplicationsListController : Controller
    {
        public IActionResult ApplicationsList()
        {
            return View();
        }
    }
}
