using Microsoft.AspNetCore.Mvc;

namespace Server_Administration_Tool.Controllers
{
    public class AppsController : Controller
    {
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

        public string StartApplication(string app)
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
