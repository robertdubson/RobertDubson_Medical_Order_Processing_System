using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;

namespace DataLayer.Repositories
{
    public class ClientRepository : GenericRepository<ClientEntity, int>, IClientRepository
    {
        public ClientRepository(DbContext context) : base(context)
        {

        }
    }
}
