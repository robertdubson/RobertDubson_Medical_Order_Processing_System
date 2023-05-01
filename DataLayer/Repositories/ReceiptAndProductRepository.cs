using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
using Microsoft.EntityFrameworkCore;
using DataLayer.Repositories.Abstract;
namespace DataLayer.Repositories
{
    public class ReceiptAndProductRepository : GenericRepository<ReceiptAndProductEntity, int>, IReceiptAndProductRepository
    {
        public ReceiptAndProductRepository(DbContext context) : base(context)
        {

        }
    }
}
