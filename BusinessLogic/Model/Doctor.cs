using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Doctor : User
    {
        public string Name { get; set; }

        public Doctor(int id, string name, string password, string username) : base (password, username)
        {
            ID = id;

            Name = name;

            UserName = username;

            PasswordHash = GetHashString(password);

        }

        public Doctor(string name, string password, string username) : base (password, username)
        {
            Name = name;

            UserName = username;

            PasswordHash = GetHashString(password);
        }


    }
}
