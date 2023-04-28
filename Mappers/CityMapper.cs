using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using DataModel;
namespace Mappers
{
    public class CityMapper : IMapper<CityEntity, City>
    {
        public CityEntity FromDomainToEntity(City example)
        {
            return new CityEntity(example.ID, example.CityName, example.CoordinateX, example.CoordinateY);
        }

        public City FromEntityToDomain(CityEntity example)
        {
            return new City(example.ID, example.CityName, example.CoordinateX, example.CoordinateY);
        }
    }
}
