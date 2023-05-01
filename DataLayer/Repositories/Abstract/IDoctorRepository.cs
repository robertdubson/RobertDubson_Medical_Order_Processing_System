using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace DataLayer.Repositories.Abstract
{
    public interface IDoctorRepository : IRepository<DoctorEntity, int>
    {
        public DoctorEntity GetDoctorByUsername(string username);
    }

    
}
