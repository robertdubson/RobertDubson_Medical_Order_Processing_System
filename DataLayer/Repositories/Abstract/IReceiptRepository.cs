using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace DataLayer.Repositories.Abstract
{
    public interface IReceiptRepository : IRepository<ReceiptEntity, int>
    {
        public IEnumerable<ReceiptEntity> GetReceiptsByDoctorId(int doctorId);

        public IEnumerable<ReceiptEntity> GetReceiptByClientId(int clientId);


    }
}
