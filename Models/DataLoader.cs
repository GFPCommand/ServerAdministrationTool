using Microsoft.AspNetCore.Components.Web;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Server_Administration_Tool.Models
{
    public class DataLoader
    {
        private const string USERS_FILE = "users.json";
        private const string APPS_FILE = "apps.json";

        readonly string jsonLoadUsers = string.Empty;
        readonly string jsonLoadApps  = string.Empty;

        private readonly JsonDocument docUsers;
        private readonly JsonDocument docApps;

        public DataLoader()
        {
            jsonLoadUsers = File.ReadAllText(USERS_FILE);
            jsonLoadApps  = File.ReadAllText(APPS_FILE);

            docUsers = JsonDocument.Parse(jsonLoadUsers);
            docApps  = JsonDocument.Parse(jsonLoadApps);
        }

        public bool ReadUserPassword(string? login, string? password)
        {
            try
            {
                JsonElement elem = docUsers.RootElement;

                foreach (var item in ReadAllUsers(elem))
                {
                    if (item.GetProperty(login).GetProperty("pswd").ToString().Equals(password))
                        return true;
                }
            }
            catch {}

            return false;
        }

        private JsonElement.ArrayEnumerator ReadAllUsers(JsonElement rootElement) => rootElement.GetProperty("users").EnumerateArray();

        private JsonElement.ArrayEnumerator ReadAllApps(JsonElement rootElement) => rootElement.GetProperty("apps").EnumerateArray();
        
        public List<string> Users()
        {
            List<string> users = new();

            foreach (var item in ReadAllUsers(docUsers.RootElement))
            {
                users.Add(item.GetRawText().Trimmer());
            }

            return users;
        }

        public List<string> Apps()
        {
            List<string> apps = new();

            foreach (var item in ReadAllApps(docApps.RootElement))
            {
				apps.Add(item.GetRawText().Trimmer());
            }

            return apps;
        }

        public List<Application> AppInfo()
        {
            List<Application> info = new();

            foreach (var item in ReadAllApps(docApps.RootElement))
            {

            }

            return info;
        }
    }

    public static class StringExtension
    {
        public static string Trimmer(this string str)
        {
			int index = str.IndexOf(":");

			str = str.Remove(index);
			str = str.Remove(str.Length - 1);
			str = str.Remove(0, 1);
			str = str.Replace("\"", "");

            return str;
		}
    }
}
