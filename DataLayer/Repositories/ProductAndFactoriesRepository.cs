using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
using System.Linq;
namespace DataLayer.Repositories
{
    public class ProductAndFactoriesRepository : GenericRepository<ProductAndFactoryEntity, int>, IProductAndFactoryRepository
    {
        public ProductAndFactoriesRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<ProductAndFactoryEntity> GetFactoryDetailsForFacory(int factoryid)
        {
            return _DbSet.ToList().FindAll(details => details.FactoryID==factoryid);
        }
    }
}
