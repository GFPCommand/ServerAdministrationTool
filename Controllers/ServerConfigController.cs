using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server_Administration_Tool.Controllers
{
	[Authorize]
	public class ServerConfigurationController : Controller
	{
		public IActionResult Index() 
		{
			return View();
		}
	}
}
