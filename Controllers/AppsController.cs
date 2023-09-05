using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Server_Administration_Tool.Controllers
{
    public class AppsController : Controller
    {
        private const string START_APP = "start";
        private const string STOP_APP = "stop";
        private const string RESTART_APP = "restart";
        private const string RELOAD_APP = "reload";

        public void RestartApplication(string app)
        {
            //TODO:
            //restart app: if Linux OS -> systemctl restart {app}

            ServerAppAction(app, RESTART_APP);
        }

        public void ReloadApplication(string app)
        {
            //TODO:
            //reload configs and restart app: if Linux OS -> systemctl reload {app}

            ServerAppAction(app, RELOAD_APP);
        }

        public string StartApplication(string app)
        {
            //TODO:
            //start app: if Linux OS -> systemctl start {app}

            ServerAppAction(app, START_APP);

            return app;
        }

        public void StopApplication(string app)
        {
            //TODO:
            //stop app: if Linux OS -> systemctl stop {app}
            
            ServerAppAction(app, STOP_APP);
        }

        private void ServerAppAction(string appName, string action)
        {
            if (!OperatingSystem.IsLinux()) return;

            try
            {
                ProcessStartInfo info = new();
                info.WindowStyle = ProcessWindowStyle.Hidden;
                info.FileName = "/bin/bash";
                info.UseShellExecute = false;
                info.Arguments = $"/c systemctl {action} {appName}";

                using Process process = new() {StartInfo = info};

                process.Start();

                process.WaitForExit();
            }
            catch
            {
                return;
            }            
        }
    }
}
