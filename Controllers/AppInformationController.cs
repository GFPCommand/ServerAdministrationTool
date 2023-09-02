using Microsoft.AspNetCore.Mvc;
using Server_Administration_Tool.Models;

namespace Server_Administration_Tool.Controllers
{
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
