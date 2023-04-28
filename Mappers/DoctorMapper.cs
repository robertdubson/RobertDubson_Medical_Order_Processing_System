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
            return new DoctorEntity(example.ID, example.Name, example.PasswordHash, example.UserName);
        }

        public Doctor FromEntityToDomain(DoctorEntity example)
        {
            return new Doctor(example.ID, example.Name, example.PasswordHash, example.UserName);
        }
    }
}
