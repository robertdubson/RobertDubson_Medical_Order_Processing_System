using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
using System.Linq;
namespace DataLayer.Repositories
{
    public class CompaniesAndCitiesRepository : GenericRepository<DeliveryCompanyAndCityEntity, int>, ICompanyAndCityRepository
    {
        public CompaniesAndCitiesRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<DeliveryCompanyAndCityEntity> GetCompanyDetails(int id)
        {
            return _DbSet.ToList().FindAll(cmpndt => cmpndt.CompanyID==id);
        }

    }
}
