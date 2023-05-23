using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
using System.Linq;
namespace DataLayer.Repositories
{
    public class ClientRepository : GenericRepository<ClientEntity, int>, IClientRepository
    {
        public ClientRepository(DbContext context) : base(context)
        {

        }

        public ClientEntity GetClientByUsername(string username)
        {
            return _DbSet.ToList().Find(user => user.UserName == username);
        }

        public IEnumerable<AdministratorEntity> GetAdministrators()
        {
            return Context.Set<AdministratorEntity>().ToList();
        }

        public AdministratorEntity GetAdminByUserName(string username)
        {
            return Context.Set<AdministratorEntity>().ToList().Find(user => user.UserName == username);
        }

        public AdministratorEntity GetAdminById(int Id) 
        {
            return Context.Set<AdministratorEntity>().Find(Id);
        }

        public void AddAdmin(AdministratorEntity example)
        {
            Context.Set<AdministratorEntity>().Add(example);
            Context.SaveChanges();
        }

        public void DeleteAdmin(int Id)
        {
            Context.Set<AdministratorEntity>().Remove(Context.Set<AdministratorEntity>().Find(Id));
            Context.SaveChanges();
        }

        public void UpdateAdmin(AdministratorEntity example)
        {
            Context.Entry(example).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<AdministratorEntity> GetAllAdmins()
        {
            return Context.Set<AdministratorEntity>().ToList();
        }
    }
}
