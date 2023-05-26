using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
using System.Linq;
namespace DataLayer.Repositories
{
    public class SupplierAndProductRepository : GenericRepository<SupplierAndProductEntity, int>, ISupplierAndProductRepository
    {
        public SupplierAndProductRepository(DbContext context) : base(context)
        {

        }
        public IEnumerable<SupplierAndProductEntity> GetPriceList(int SupplierId) 
        {
            return _DbSet.ToList().FindAll(sp => sp.SupplierID==SupplierId);
        }

    }
}
