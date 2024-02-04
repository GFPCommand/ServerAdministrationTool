using System.Security.Cryptography;
using System.Text;

namespace ServerAdministrationTool.Models
{
    public class Authority
    {
        private DataLoader _loader;

        public Authority()
        {
            _loader = new DataLoader();
        }

        private string DataHash(string password)
        {
            byte[] bytes;

            using SHA256 hash = SHA256.Create();

            bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password!));

            return Convert.ToHexString(bytes).ToLower();
        }

        public bool LoginDataIsCorrect(string login, string password) => _loader.ReadUserPassword(login, DataHash(DataHash(password!)));
    }
}

// admin : p9gNS19prS + sha256 + sha256
// user  : 2VqYvIdBQq + sha256 + sha256