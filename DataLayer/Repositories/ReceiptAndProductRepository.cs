using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
using Microsoft.EntityFrameworkCore;
using DataLayer.Repositories.Abstract;
using System.Linq;
namespace DataLayer.Repositories
{
    public class ReceiptAndProductRepository : GenericRepository<ReceiptAndProductEntity, int>, IReceiptAndProductRepository
    {
        public ReceiptAndProductRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<ReceiptAndProductEntity> GetPrescriptedProducts(int receiptId)
        {
            return _DbSet.ToList().FindAll(rc => rc.ReceiptID == receiptId);
        }

        public new void Add(ReceiptAndProductEntity example)
        {
            _DbSet.Add(example);
            Context.SaveChanges();
        }
    }
}
