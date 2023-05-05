﻿using System;
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
            return _DbSet.ToList().Find(user => user.UserName==username);
        }
    }
}