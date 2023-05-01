using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
using System.Linq;
namespace DataLayer.Repositories
{
    public class DoctorRepository : GenericRepository<DoctorEntity, int>, IDoctorRepository
    {
        public DoctorRepository(DbContext context) : base(context)
        {
           
        }

        public DoctorEntity GetDoctorByUsername(string username) 
        {
            return _DbSet.ToList().Find(doc => doc.UserName ==username);
        }
    }
}
