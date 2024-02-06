using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ServerAdministrationTool.Models
{
	public class DataUploader : DataManager
	{
        private Authority _auth;

		private List<User> _usersList = [];

		JsonSerializerSettings settings = new()
		{
			Formatting = Formatting.Indented
		};


		public DataUploader()
        {
            _auth = new Authority();

			jsonLoadUsers = File.ReadAllText(USERS_FILE);
			jsonLoadApps = File.ReadAllText(APPS_FILE);
		}

        public void WriteNewUser(string login, string password, string role)
        {
            var pswdHash = _auth.DataHash(_auth.DataHash(password));

			User user = new() { Name = login, Password = pswdHash, Role = role};

			_usersList = UsersList();

			_usersList.Add(user);

			Dictionary<string, List<User>> vals = new Dictionary<string, List<User>>
			{
				{ "users", _usersList }
			};

			File.WriteAllText(USERS_FILE, JsonConvert.SerializeObject(vals, settings));
        }

		protected override List<Application> ApplicationsList()
		{
			throw new NotImplementedException();
		}

		// выкинуть в базовый класс как и в loader'е
		protected override List<User> UsersList()
        {
			List<User> users = [];

			var json = JsonConvert.DeserializeObject<JObject>(jsonLoadUsers);

			var elems = json["users"].ToList();

			foreach ( var item in elems )
			{
				var user = JsonConvert.DeserializeObject<User>(item.ToString());

				users.Add(user);
			}

			return users;
        }
    }
}
