using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
using System.Linq;
namespace DataLayer.Repositories
{
    public class FactoryRepository : GenericRepository<FactoryEntity, int>, IFactoryRepository
    {
        public FactoryRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<FactoryEntity> GetFactoriesBySupplierId(int supplierId)
        {
            return _DbSet.ToList().FindAll(fac => fac.CompanyID==supplierId);
        }
    }
}
