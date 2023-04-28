using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class User : BaseModel, IUser
    {        

        public string UserName { get; protected set; }

        public string PasswordHash { get; protected set; }

        public User(int id , string passwordHash, string username)
        {
            ID = id;

            UserName = username;

            PasswordHash = passwordHash;
        }

        public User(string password, string username) 
        {
            UserName = username;

            PasswordHash = GetHashString(password);

        }
        

        public virtual bool Login(string password, string username)
        {
            return GetHashString(password) == PasswordHash & username == UserName;
        }

        public virtual void Logout()
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
