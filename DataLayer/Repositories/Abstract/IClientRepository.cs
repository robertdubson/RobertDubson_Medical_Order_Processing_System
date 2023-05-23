using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace DataLayer.Repositories.Abstract
{
    public interface IClientRepository : IRepository<ClientEntity, int>
    {
        ClientEntity GetClientByUsername(string username);
        
        IEnumerable<AdministratorEntity> GetAdministrators();
        
        AdministratorEntity GetAdminByUserName(string username);
        
        void AddAdmin(AdministratorEntity example);

        void DeleteAdmin(int Id);

        void UpdateAdmin(AdministratorEntity example);

        IEnumerable<AdministratorEntity> GetAllAdmins();
        AdministratorEntity GetAdminById(int Id);
    }
}
