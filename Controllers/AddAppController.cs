using Microsoft.AspNetCore.Mvc;

namespace Server_Administration_Tool.Controllers
{
    public class AddAppController : Controller
    {
        public IActionResult AddApplication()
        {
            return View();
        }
    }
}
