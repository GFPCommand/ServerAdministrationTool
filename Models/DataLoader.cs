using Microsoft.AspNetCore.Components.Web;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Server_Administration_Tool.Models
{
    public class DataLoader
    {
        readonly string jsonLoad = string.Empty;

        private readonly JsonDocument doc;

        public DataLoader()
        {
            jsonLoad = File.ReadAllText("users.json");

            doc = JsonDocument.Parse(jsonLoad);
        }

        public bool ReadUserPassword(string login, string password)
        {
            try
            {
                JsonElement elem = doc.RootElement;

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
        
        public List<string> Users()
        {
            List<string> users = new();

            foreach (var item in ReadAllUsers(doc.RootElement))
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
    }
}
