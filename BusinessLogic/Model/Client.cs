using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Client : User
    {
        public int LocationID { get; set; }

        public string Name { get; set; }

        public Client(int id, string name, int locationID, string passwordHash, string username) : base(passwordHash, username)
        {
            ID = id;

            Name = name;

            LocationID = locationID;

            UserName = username;

            PasswordHash = passwordHash;

        }

        

    }
}
