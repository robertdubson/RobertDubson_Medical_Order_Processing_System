using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
namespace DataLayer.Repositories
{
    public class ProductAndFactoriesRepository : GenericRepository<ProductAndFactoryEntity, int>, IProductAndFactoryRepository
    {
        public ProductAndFactoriesRepository(DbContext context) : base(context)
        {

        }

        
    }
}
