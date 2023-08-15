﻿using System.Security.Cryptography;
using System.Text;

namespace Server_Administration_Tool.Models
{
    public class Authority
    {
        private DataLoader _loader;

        public Authority()
        {
            _loader = new DataLoader();
        }

        private string DataHash(string? password)
        {
            byte[] bytes;

            string str = string.Empty;

            using (SHA256 hash = SHA256.Create())
            {
                bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                foreach (var b in bytes)
                {
                    str += b.ToString();
                }
            }

            return Convert.ToHexString(bytes).ToLower();
        }

        public bool LoginDataIsCorrect(string? login, string? password) => _loader.ReadUserPassword(login, DataHash(DataHash(password)));
    }
}
