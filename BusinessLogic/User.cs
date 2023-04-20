using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class User : IUser
    {

        public int ID { get; private set; }

        public string UserName { get; private set; }

        private string _passwordHash;

        public string UserEmail { get; private set; }

        public User(string password, string username) 
        {
            UserName = username;

            _passwordHash = GetHashString(password);

        }
        

        public bool Login(string password, string username)
        {
            return GetHashString(password) == _passwordHash & username == UserName;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
