using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
using BusinessLogic.Model;
namespace Mappers
{
    public class AdminMapper : IMapper<AdministratorEntity, Administrator>
    {
        public AdministratorEntity FromDomainToEntity(Administrator example)
        {
            AdministratorEntity admin = new AdministratorEntity();

            admin.ClientName = example.ClientName;
            admin.EMail = example.EMail;
            admin.ID = example.ID;
            admin.LocationID = example.LocationID;
            admin.Phone = example.Phone;
            admin.UserName = example.UserName;
            admin.PasswordHash = example.PasswordHash;
            return admin;
        }

        public Administrator FromEntityToDomain(AdministratorEntity example)
        {
            Administrator admin = new Administrator();

            admin.ClientName = example.ClientName;
            admin.EMail = example.EMail;
            admin.ID = example.ID;
            admin.LocationID = example.LocationID;
            admin.Phone = example.Phone;
            admin.UserName = example.UserName;
            admin.PasswordHash = example.PasswordHash;
            return admin;
        }

        public AdministratorEntity NewExample(Administrator example)
        {
            AdministratorEntity admin = new AdministratorEntity();

            admin.ClientName = example.ClientName;
            admin.EMail = example.EMail;
            admin.LocationID = example.LocationID;
            admin.Phone = example.Phone;
            admin.UserName = example.UserName;
            admin.PasswordHash = example.PasswordHash;
            return admin;

        }
    }
}
