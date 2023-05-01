using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
namespace DataLayer.Repositories
{
    public class FactoryRepository : GenericRepository<FactoryEntity, int>, IFactoryRepository
    {
        public FactoryRepository(DbContext context) : base(context)
        {

        }
    }
}
