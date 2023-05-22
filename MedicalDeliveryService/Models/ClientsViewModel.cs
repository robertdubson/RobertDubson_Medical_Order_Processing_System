using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
namespace MedicalDeliveryService.Models
{
    public class ClientsViewModel
    {
        public int ID { get; set; }
        
        public string ClientName { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public int LocationID { get; set; }

        public City Location { get; set; }

        public string Phone { get; set; }

        public string EMail { get; set; }

        public ClientsViewModel()
        {

        }

        public ClientsViewModel(int id, string cname, City city, string passwordHash, string username, string phone, string email)
        {
            ID = id;

            UserName = username;

            PasswordHash = passwordHash;

            ClientName = cname;

            Location = city;

            Phone = phone;

            EMail = email;
        }
    }
}
