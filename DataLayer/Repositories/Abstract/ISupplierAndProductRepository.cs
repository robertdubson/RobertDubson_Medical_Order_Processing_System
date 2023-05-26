using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace DataLayer.Repositories.Abstract
{
    public interface ISupplierAndProductRepository : IRepository<SupplierAndProductEntity, int>
    {

        IEnumerable<SupplierAndProductEntity> GetPriceList(int SupplierId);
    }


}
