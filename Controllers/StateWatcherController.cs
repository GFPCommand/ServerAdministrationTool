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
                //string app = string.Empty;

                //Process[] proc = Process.GetProcessesByName(app);

                //output = proc.Length > 0 ? "OK" : "Stopped";

                Dictionary<string, string> a = new Dictionary<string, string>();

                a.Add("ewrdg","jfn");
                a.Add("sdff","dsd");
                a.Add("wedsfg","rdg");

                output = JsonSerializer.Serialize(a);
            }

            return output;
        }
    }
}