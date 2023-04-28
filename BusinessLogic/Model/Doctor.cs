using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Doctor : User
    {
        public string Name { get; set; }

        public Doctor(int id, string name, string passwordHash, string username) : base (passwordHash, username)
        {
            ID = id;

            Name = name;

            UserName = username;

            PasswordHash = passwordHash;

        }



    }
}
