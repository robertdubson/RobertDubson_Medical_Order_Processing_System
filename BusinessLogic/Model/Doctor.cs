using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Doctor : User
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string EMail { get; set; }

        public int LocationID { get; set; }

        public Doctor(int id, string name, string phone, string email, int locationId, string passwordHash, string username) : base (passwordHash, username)
        {
            ID = id;

            Name = name;

            UserName = username;

            PasswordHash = passwordHash;

            Phone = phone;

            EMail = email;

            LocationID = locationId;


        }



    }
}
