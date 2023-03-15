using System;
using System.Security.Cryptography;
using System.Text;

namespace AdminPanel.Domain.helpers
{
    public static class HashHelper
    {
        public static string Hash(string value)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "" ).ToLower();
                return hash;
            }
        }
    }
}
