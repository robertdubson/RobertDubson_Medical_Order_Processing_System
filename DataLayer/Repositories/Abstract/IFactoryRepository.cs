using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace DataLayer.Repositories.Abstract
{
    public interface IFactoryRepository : IRepository<FactoryEntity, int>
    {
        IEnumerable<FactoryEntity> GetFactoriesBySupplierId(int supplierId);
    }
}
