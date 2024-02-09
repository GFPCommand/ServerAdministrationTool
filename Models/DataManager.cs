using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ServerAdministrationTool.Models
{
	public abstract class DataManager
	{
		protected const string USERS_FILE = "users.json";
		protected const string APPS_FILE = "apps.json";

		protected string jsonLoadUsers = string.Empty;
		protected string jsonLoadApps = string.Empty;

		protected virtual List<User> UsersList()
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
		protected virtual List<Application> ApplicationsList()
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
