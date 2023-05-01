using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;

namespace DataLayer.Repositories
{
    public class CompaniesAndCitiesRepository : GenericRepository<DeliveryCompanyAndCityEntity, int>, ICompanyAndCityRepository
    {
        public CompaniesAndCitiesRepository(DbContext context) : base(context)
        {

        }
    }
}
