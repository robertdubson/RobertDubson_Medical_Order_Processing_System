using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
using System.Linq;
namespace DataLayer.Repositories
{
    public class ReceiptRepository : GenericRepository<ReceiptEntity, int>, IReceiptRepository
    {
        public ReceiptRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<ReceiptEntity> GetReceiptByClientId(int clientId) 
        {
            return _DbSet.ToList().FindAll(rec => rec.ClientID == clientId);
        }

        public IEnumerable<ReceiptEntity> GetReceiptsByDoctorId(int doctorId)
        {
            return _DbSet.ToList().FindAll(rec => rec.AuthorID == doctorId);
        }
    }
}
