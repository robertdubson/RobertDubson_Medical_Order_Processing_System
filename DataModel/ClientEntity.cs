using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class ClientEntity : BaseEntity
    {
        
        public string ClientName { get; set; }
        
        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public ClientEntity(int id, string cname, string passwordHash, string username)
        {
            ID = id;

            UserName = username;

            PasswordHash = passwordHash;

            ClientName = cname;
        }

        public ClientEntity(string passwordHash, string username, string clienName)
        {
            UserName = username;

            PasswordHash = passwordHash;

            ClientName = clienName;

        }
    }
}
