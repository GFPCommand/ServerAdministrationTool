using Microsoft.AspNetCore.Components.Web;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Server_Administration_Tool.Models
{
    public class DataLoader
    {
        readonly string jsonLoadUsers = string.Empty;
        readonly string jsonLoadApps  = string.Empty;

        private readonly JsonDocument docUsers;
        private readonly JsonDocument docApps;

        public DataLoader()
        {
            jsonLoadUsers = File.ReadAllText("users.json");
            jsonLoadApps  = File.ReadAllText("apps.json");

            docUsers = JsonDocument.Parse(jsonLoadUsers);
            docApps  = JsonDocument.Parse(jsonLoadApps);
        }

        public bool ReadUserPassword(string login, string password)
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
            catch
            {
                return false;
            }

            return false;
        }

        private JsonElement.ArrayEnumerator ReadAllUsers(JsonElement rootElement)
        {
            return rootElement.GetProperty("users").EnumerateArray();
        }

        private JsonElement.ArrayEnumerator ReadAllApps(JsonElement rootElement){
            return rootElement.GetProperty("apps").EnumerateArray();
        }
        
        public List<string> Users()
        {
            List<string> users = new();

            foreach (var item in ReadAllUsers(docUsers.RootElement))
            {
                string elem = item.GetRawText();

                int index = elem.IndexOf(":");

                elem = elem.Remove(index);
                elem = elem.Remove(elem.Length - 1);
                elem = elem.Remove(0,1);
                elem = elem.Replace("\"", "");

                users.Add(elem);
            }

            return users;
        }

        public List<string> Apps()
        {
            List<string> apps = new();

            foreach (var item in ReadAllApps(docApps.RootElement))
            {
                apps.Add(item.GetString());
            }

            return apps;
        }
    }
}
