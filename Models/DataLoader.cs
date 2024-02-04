using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ServerAdministrationTool.Models
{
    public class DataLoader
    {
        private const string USERS_FILE = "users.json";
        private const string APPS_FILE = "apps.json";

        readonly string jsonLoadUsers = string.Empty;
        readonly string jsonLoadApps = string.Empty;

        private string _userName = string.Empty;

        public DataLoader()
        {
            jsonLoadUsers = File.ReadAllText(USERS_FILE);
            jsonLoadApps = File.ReadAllText(APPS_FILE);
        }

        public bool ReadUserPassword(string login, string password)
        {
            _userName = login;

            foreach (var item in UsersList())
            {
                if (item.Name.Equals(login) && item.Password.Equals(password))
                {
                    return true;
                }
            }

            return false;
        }

        public List<string> Users()
        {
            List<string> users = [];

            foreach (var item in UsersList())
            {
                users.Add(item.Name);
            }

            return users;
        }

        public List<string> Apps()
        {
            List<string> apps = [];

            foreach (var item in ApplicationsList())
            {
                apps.Add(item.Name);
            }

            return apps;
        }

        public string UserInfo()
        {
            string info = string.Empty;

            foreach (var item in UsersList())
            {
                if (item.Name.Equals(_userName))
                    info = JsonConvert.SerializeObject(item);
            }

            return info;
        }

        public string AppInfo(string objName)
        {
            string info = string.Empty;

            foreach (var item in ApplicationsList())
            {
                if (item.Name.Equals(objName))
                {
                    info = JsonConvert.SerializeObject(item);
                }
            }

            return info;
        }

        private List<User> UsersList()
        {
            List<User> users = [];

            var json = JsonConvert.DeserializeObject<JObject>(jsonLoadUsers);

            var elems = json["users"].ToList();

            foreach (var item in elems)
            {
                var user = JsonConvert.DeserializeObject<User>(item.ToString());

                users.Add(user);
            }

            return users;
        }

        private List<Application> ApplicationsList()
        {
            List<Application> apps = [];

            var json = JsonConvert.DeserializeObject<JObject>(jsonLoadApps);

            var elems = json["apps"].ToList();

            foreach (var item in elems)
            {
                var app = JsonConvert.DeserializeObject<Application>(item.ToString());

                apps.Add(app);
            }

            return apps;
        }
    }
}
