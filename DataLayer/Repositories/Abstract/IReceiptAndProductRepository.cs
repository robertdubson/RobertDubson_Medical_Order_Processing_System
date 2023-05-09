using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace DataLayer.Repositories.Abstract
{
    public interface IReceiptAndProductRepository : IRepository<ReceiptAndProductEntity, int>
    {
        public IEnumerable<ReceiptAndProductEntity> GetPrescriptedProducts(int receiptId);
    }
}
