﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class ClientEntity : BaseEntity
    {
        
        public string ClientName { get; set; }
        
        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public int LocationID { get; set; }

        public string Phone { get; set; }

        public string EMail { get; set; }

        public ClientEntity()
        {

        }

        public ClientEntity(int id, string cname, int locationId, string passwordHash, string username, string phone, string mail)
        {
            ID = id;

            UserName = username;

            PasswordHash = passwordHash;

            ClientName = cname;

            LocationID = locationId;

            Phone = phone;

            EMail = mail;
        }

        public ClientEntity(string passwordHash, string username, string clienName, int locationId, string phone, string mail)
        {
            UserName = username;

            PasswordHash = passwordHash;

            ClientName = clienName;

            LocationID = locationId;

            Phone = phone;

            EMail = mail;

        }
    }
}
