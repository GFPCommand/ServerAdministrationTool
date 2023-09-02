namespace Server_Administration_Tool.Models
{
	public class User
	{
		public string Login { get; set; } = null!;

		public string Password { get; set; } = null!;

		public string Role { get; set; } = null!;

		public bool isCorrect = true;
	}
}
//admin : p9gNS19prS + sha256 + sha256