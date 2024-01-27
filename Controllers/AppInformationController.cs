using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerAdministrationTool.Models;

namespace Server_Administration_Tool.Controllers
{
    [Authorize]
    public class AppInformationController : Controller
    {
        [HttpGet]
        public string AppInfo(string objName)
        {
            DataLoader loader = new();

            string json = loader.AppInfo(objName);

            return json;
        }
    }
}
