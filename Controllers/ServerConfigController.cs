using Microsoft.AspNetCore.Mvc;

namespace Server_Administration_Tool.Controllers
{
	public class ServerConfigController : Controller
	{
		public IActionResult Index() 
		{ 
			return View();
		}

		public IActionResult ServerConfiguration()
		{
			return View();
		}
	}
}
