namespace Server_Administration_Tool.Models
{
	public class AuthorityModel
	{
		public string? Login { get; set; }

		public string? Password { get; set; }

		public string? Role { get; set; }

		public bool isCorrect = true;
	}
}
//admin : p9gNS19prS + sha256 + sha256