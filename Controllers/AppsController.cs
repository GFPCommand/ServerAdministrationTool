using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Server_Administration_Tool.Models;
using System.Diagnostics;

namespace Server_Administration_Tool.Controllers
{
    public class AppsController : Controller
    {
		public void StartApplication(string app)
		{
			if (OperatingSystem.IsLinux())
			{
				ServiceAction(Actions.Start.ToString(), app);
			}
		}

		public void StopApplication(string app)
		{
			if (OperatingSystem.IsLinux())
			{
				ServiceAction(Actions.Stop.ToString(), app);
			}
		}

		public void RestartApplication(string app)
        {
            //TODO:
            //restart app: if Linux OS -> systemctl restart {app}
        }

        public void ReloadApplication(string app)
        {
            //TODO:
            //reload configs and restart app: if Linux OS -> systemctl reload {app}
        }

        private void ServiceAction(string actionName, string appName)
        {
            //TODO:
            //start app: if Linux OS -> systemctl start {app}
            return app;
        }

        public void StopApplication(string app)
        {
            //TODO:
            //stop app: if Linux OS -> systemctl stop {app}
        }
    }
}
