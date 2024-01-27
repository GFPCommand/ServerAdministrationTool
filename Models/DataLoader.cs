using System.Text.Json;

namespace ServerAdministrationTool.Models
{
    public class DataLoader
    {
        private const string USERS_FILE = "users.json";
        private const string APPS_FILE = "apps.json";

        readonly string jsonLoadUsers = string.Empty;
        readonly string jsonLoadApps = string.Empty;

        private readonly JsonDocument docUsers;
        private readonly JsonDocument docApps;

        public DataLoader()
        {
            jsonLoadUsers = File.ReadAllText(USERS_FILE);
            jsonLoadApps = File.ReadAllText(APPS_FILE);

            docUsers = JsonDocument.Parse(jsonLoadUsers);
            docApps = JsonDocument.Parse(jsonLoadApps);
        }

        public bool ReadUserPassword(string login, string password)
        {
            try
            {
                JsonElement elem = docUsers.RootElement;

                foreach (var item in ReadAllUsers(elem))
                {
                    if (item.GetProperty(login!).GetProperty("pswd").ToString().Equals(password))
                        return true;
                }
            }
            catch
            {
                return false;
            }

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
            List<string> apps = [];

            foreach (var item in ReadAllApps(docApps.RootElement))
            {
                apps.Add(item.GetRawText().Trimmer());
            }

            return apps;
        }

        public string AppInfo(string objName)
        {
            string info = string.Empty;

            foreach (var item in ReadAllApps(docApps.RootElement))
            {
                if (item.GetRawText().Trimmer().Equals(objName))
                {
                    info = item.GetRawText();

                    info = info.Remove(0, 1);

                    int index = info.IndexOf('{');

                    info = info.Remove(0, index - 1);

                    info = info.Remove(info.Length - 1);
                }
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
            str = str.Trim();

            return str;
        }
    }
}
