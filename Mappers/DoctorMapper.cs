using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
using BusinessLogic;
namespace Mappers
{
    public class DoctorMapper : IMapper<DoctorEntity, Doctor>
    {
        public DoctorEntity FromDomainToEntity(Doctor example)
        {

            return new DoctorEntity(example.ID, example.Name, example.PasswordHash, example.UserName, example.LocationID, example.Phone, example.EMail);
        }

        public Doctor FromEntityToDomain(DoctorEntity example)
        {
            if (example!=null) 
            {
                return new Doctor(example.ID, example.Name, example.Phone, example.EMail, example.LocationID, example.PasswordHash, example.UserName);
            }
            return null;
            
        }

        public DoctorEntity NewExample(Doctor example)
        {
            return new DoctorEntity(example.Name, example.PasswordHash, example.UserName, example.LocationID, example.Phone, example.EMail);
        }
    }
}
