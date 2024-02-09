using Newtonsoft.Json;

namespace ServerAdministrationTool.Models
{
    public class DataLoader : DataManager
    {
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

        public string UserInfo(string user)
        {
            string info = string.Empty;

            foreach (var item in UsersList())
            {
                if (item.Name.Equals(user))
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
    }
}
