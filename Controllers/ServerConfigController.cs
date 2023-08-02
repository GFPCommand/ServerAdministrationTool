using Microsoft.AspNetCore.Mvc;

namespace Server_Administration_Tool.Controllers
{
	public class ServerConfigController : Controller
	{
		public IActionResult ServerConfiguration()
		{
			return View();
		}
	}
}
