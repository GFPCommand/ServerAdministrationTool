using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerAdministrationTool.Models;
using System.Diagnostics;

namespace Server_Administration_Tool.Controllers
{
	[Authorize]
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
			if (OperatingSystem.IsLinux())
			{
				ServiceAction(Actions.Restart.ToString(), app);
			}
		}

        public void ReloadApplication(string app)
        {
			if (OperatingSystem.IsLinux())
			{
				ServiceAction(Actions.Reload.ToString(), app);
			}
		}

        private void ServiceAction(string actionName, string appName)
        {
			var args = actionName.Contains("Reload") ?
				$"/c systemctl reload {appName} && systemctl restart {appName}" :
				$"/c systemctl {actionName.ToLower()} {appName}";

			ProcessStartInfo info = new();
			info.WindowStyle = ProcessWindowStyle.Hidden;
			info.FileName = "/bin/bash";
			info.RedirectStandardOutput = true;
			info.UseShellExecute = false;
			info.Arguments = args;
			using var proc = new Process() { StartInfo = info };
			proc.Start();

			proc.WaitForExit();
		}
    }
}
