using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
namespace DataLayer.Repositories
{
    public class SupplierRepository : GenericRepository<SupplierEntity, int>, ISupplierRepository
    {
        public SupplierRepository(DbContext context) : base(context)
        {

        }
    }
}
