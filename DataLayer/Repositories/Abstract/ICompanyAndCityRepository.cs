using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace DataLayer.Repositories.Abstract
{
    public interface ICompanyAndCityRepository : IRepository<DeliveryCompanyAndCityEntity, int>
    {
        IEnumerable<DeliveryCompanyAndCityEntity> GetCompanyDetails(int id);

    }
}
