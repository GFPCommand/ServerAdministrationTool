using Newtonsoft.Json;

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

        public bool WriteData(out string err, UserActions action, string login, string password = "", string role = "")
        {
			err = string.Empty;
			try
			{
				var pswdHash = _auth.DataHash(_auth.DataHash(password));

				User user = new() { Name = login, Password = pswdHash, Role = role };

				_usersList = UsersList();

				switch (action)
				{
					case UserActions.CREATE:
                        _usersList.Add(user);
                        break;
					case UserActions.UPDATE:
                        foreach (var item in _usersList)
                        {
                            if (item.Name.Equals(login))
                            {
                                item.Password = pswdHash;
                            }
                        }
                        break;
					case UserActions.DELETE:
						int index = 0;
						foreach (var item in _usersList.ToList())
						{
							if (item.Name.Equals(login))
							{
								_usersList.RemoveAt(index);
                            }

							index++;
						}
						break;
				}

                Dictionary<string, List<User>> vals = new()
                {
					{ "users", _usersList }
				};

				File.WriteAllText(USERS_FILE, JsonConvert.SerializeObject(vals, settings));
			} catch (Exception ex)
			{
				err = ex.Message;

				return false;
			}

			return true;
        }
    }
}
