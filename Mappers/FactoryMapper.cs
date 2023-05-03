using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
using BusinessLogic;
namespace Mappers
{
    public class FactoryMapper : IMapper<FactoryEntity, Factory>
    {
        public FactoryEntity FromDomainToEntity(Factory example)
        {
            return new FactoryEntity(example.ID, example.CityID, example.Address, example.CompanyID);
        }

        public Factory FromEntityToDomain(FactoryEntity example)
        {
            return new Factory(example.ID, example.CityID, example.Address, example.CompanyID);
        }

        public FactoryEntity NewExample(Factory example)
        {
            return new FactoryEntity( example.CityID, example.Address, example.CompanyID);
        }
    }
}
