using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class DoctorEntity : BaseEntity
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public int LocationID { get; set; }

        public string Phone { get; set; }

        public string EMail { get; set; }

        public DoctorEntity(int id, string cname, string passwordHash, string username, int locationId, string phone, string email)
        {
            ID = id;

            UserName = username;

            PasswordHash = passwordHash;

            Name = cname;

            Phone = phone;

            EMail = email;

            LocationID = locationId;
        }

        public DoctorEntity(string cname, string passwordHash, string username, int locationId, string phone, string email)
        {

            UserName = username;

            PasswordHash = passwordHash;

            Name = cname;

            Phone = phone;

            EMail = email;

            LocationID = locationId;

        }

        public DoctorEntity()
        {

        }
    }
}
