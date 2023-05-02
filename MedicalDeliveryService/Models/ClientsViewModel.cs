using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDeliveryService.Models
{
    public class ClientsViewModel
    {
        public int ID { get; set; }
        
        public string ClientName { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public int LocationID { get; set; }

        public ClientsViewModel()
        {

        }

        public ClientsViewModel(int id, string cname, int locationId, string passwordHash, string username)
        {
            ID = id;

            UserName = username;

            PasswordHash = passwordHash;

            ClientName = cname;

            LocationID = locationId;
        }
    }
}
