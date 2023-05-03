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

        public DoctorEntity(int id, string cname, string passwordHash, string username)
        {
            ID = id;

            UserName = username;

            PasswordHash = passwordHash;

            Name = cname;
        }

        public DoctorEntity(string cname, string passwordHash, string username)
        {

            UserName = username;

            PasswordHash = passwordHash;

            Name = cname;
        }

        public DoctorEntity()
        {

        }
    }
}
