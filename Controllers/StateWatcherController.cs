using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Server_Administration_Tool.Controllers
{
    public class StateWatcherControlle : Controller
    {
        public string CheckState()
        {
            string output = string.Empty;

            if (OperatingSystem.IsLinux())
            {
                string app = string.Empty;

                ProcessStartInfo info = new();
                info.WindowStyle = ProcessWindowStyle.Hidden;
                info.FileName = "/bin/bash";
                info.RedirectStandardOutput = true;
                info.UseShellExecute = false;
                info.Arguments = $"/c systemctl is-active {app}";
                using var proc = new Process() {StartInfo = info};
                proc.Start();

                output = proc.StandardOutput.ReadToEnd();

                proc.WaitForExit();
            } else if (OperatingSystem.IsWindows())
            {
                string app = string.Empty;

                Process[] proc = Process.GetProcessesByName(app);

                output = proc.Length > 0 ? "OK" : "Stopped";
            }

            return output;
        }
    }
}