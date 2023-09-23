using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Server_Administration_Tool.Controllers
{
    public class StateWatcherController : Controller
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
                string a = string.Empty;

                Random random = new();

                a = random.Next(100).ToString();

                output = JsonSerializer.Serialize(a);
            }

            return output;
        }
    }
}