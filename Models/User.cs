using Newtonsoft.Json;

namespace ServerAdministrationTool.Models
{
    public class User
    {
        public string Name { get; set; }
        [JsonProperty("pswd")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
