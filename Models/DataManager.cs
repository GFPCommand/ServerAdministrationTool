namespace ServerAdministrationTool.Models
{
	public abstract class DataManager
	{
		protected const string USERS_FILE = "users.json";
		protected const string APPS_FILE = "apps.json";

		protected string jsonLoadUsers = string.Empty;
		protected string jsonLoadApps = string.Empty;

		protected abstract List<User> UsersList();
		protected abstract List<Application> ApplicationsList();
	}
}
