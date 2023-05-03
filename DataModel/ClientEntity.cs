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

        public int LocationID { get; set; }

        public ClientEntity()
        {

        }

        public ClientEntity(int id, string cname, int locationId, string passwordHash, string username)
        {
            ID = id;

            UserName = username;

            PasswordHash = passwordHash;

            ClientName = cname;

            LocationID = locationId;
        }

        public ClientEntity(string passwordHash, string username, string clienName, int locationId)
        {
            UserName = username;

            PasswordHash = passwordHash;

            ClientName = clienName;

            LocationID = locationId;

        }
    }
}
