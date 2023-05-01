using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
namespace DataLayer.Repositories
{
    public class DoctorRepository : GenericRepository<DoctorEntity, int>, IDoctorRepository
    {
        public DoctorRepository(DbContext context) : base(context)
        {
           
        }
    }
}
