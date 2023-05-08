using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using DataModel;
namespace Mappers
{
    public class ReceiptAndProductMapper : IMapper<ReceiptAndProductEntity, ReceiptAndProduct>
    {
        public ReceiptAndProductEntity FromDomainToEntity(ReceiptAndProduct example)
        {
            return new ReceiptAndProductEntity(example.ID, example.ReceiptID, example.ProductID, example.CityID, example.FactoryID, example.DeliveryCompanyID);
        }

        public ReceiptAndProduct FromEntityToDomain(ReceiptAndProductEntity example)
        {
            return new ReceiptAndProduct(example.ID, example.ReceiptID, example.ProductID, example.CityID, example.FactoryID, example.DeliveryCompanyID);
        }

        public ReceiptAndProductEntity NewExample(ReceiptAndProduct example)
        {
            return new ReceiptAndProductEntity(example.ReceiptID, example.ProductID, example.CityID, example.FactoryID, example.DeliveryCompanyID);
        }
    }
}
