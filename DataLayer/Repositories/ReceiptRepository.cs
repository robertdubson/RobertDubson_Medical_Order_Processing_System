using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
namespace DataLayer.Repositories
{
    public class ReceiptRepository : GenericRepository<ReceiptEntity, int>, IReceiptRepository
    {
        public ReceiptRepository(DbContext context) : base(context)
        {

        }
    }
}
