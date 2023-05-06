using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDeliveryService.Models
{
    public class DoctorViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Password { get; set; }

        public DoctorViewModel(int id, string cname, string passwordHash, string username)
        {
            ID = id;

            UserName = username;

            PasswordHash = passwordHash;

            Name = cname;
        }

        public DoctorViewModel(string cname, string passwordHash, string username)
        {

            UserName = username;

            PasswordHash = passwordHash;

            Name = cname;
        }
    }
}
