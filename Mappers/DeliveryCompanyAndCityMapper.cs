using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using DataModel;

namespace Mappers
{
    public class DeliveryCompanyAndCityMapper : IMapper<DeliveryCompanyAndCityEntity, DeliveryCompanyAndCity>
    {
        public DeliveryCompanyAndCityEntity FromDomainToEntity(DeliveryCompanyAndCity example)
        {
            return new DeliveryCompanyAndCityEntity(example.ID, example.CompanyID, example.CityID, example.AvailableCouriers);
        }

        public DeliveryCompanyAndCity FromEntityToDomain(DeliveryCompanyAndCityEntity example)
        {
            return new DeliveryCompanyAndCity(example.ID, example.CompanyID, example.CityID, example.AvailableCouriers);
        }
    }
}
