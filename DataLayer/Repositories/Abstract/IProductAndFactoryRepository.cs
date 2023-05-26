using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace DataLayer.Repositories.Abstract
{
    public interface IProductAndFactoryRepository : IRepository<ProductAndFactoryEntity, int>
    {
        IEnumerable<ProductAndFactoryEntity> GetFactoryDetailsForFacory(int factoryid);
    }
}
