using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Repositories.Abstract;
using DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class CityRepository : GenericRepository<CityEntity, int>, ICityRepository 
    { 
        public CityRepository(DbContext context) : base(context)
        {

        }
    }
}
