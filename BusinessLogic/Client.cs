using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Client : User
    {
        public int LocationID { get; set; }

        public string Name { get; set; }

        public Client(int id, string name, int locationID, string password, string username) : base(password, username)
        {
            ID = id;

            Name = name;

            LocationID = locationID;

            UserName = username;

            PasswordHash = GetHashString(password);

        }

        public Client(string name, int locationID, string password, string username) : base(password, username)
        {
            Name = name;

            UserName = username;

            PasswordHash = GetHashString(password);

            LocationID = locationID;
        }

    }
}
