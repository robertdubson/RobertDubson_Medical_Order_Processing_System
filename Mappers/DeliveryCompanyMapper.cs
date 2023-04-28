using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using DataModel;
namespace Mappers
{
    public class DeliveryCompanyMapper : IMapper<DeliveryCompanyEntity, DeliveryCompany>
    {
        public DeliveryCompanyEntity FromDomainToEntity(DeliveryCompany example)
        {
            return new DeliveryCompanyEntity(example.ID, example.Name, example.PriceForKm);
        }

        public DeliveryCompany FromEntityToDomain(DeliveryCompanyEntity example)
        {
            return new DeliveryCompany(example.ID, example.Name, example.PriceForKm);
        }
    }
}
