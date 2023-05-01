using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
namespace DataLayer.Repositories
{
    public class SupplierAndProductRepository : GenericRepository<SupplierAndProductEntity, int>, ISupplierAndProductRepository
    {
        public SupplierAndProductRepository(DbContext context) : base(context)
        {

        }
    }
}
