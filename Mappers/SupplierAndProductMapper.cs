using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using DataModel;
namespace Mappers
{
    public class SupplierAndProductMapper : IMapper<SupplierAndProductEntity, SupplierAndProduct>
    {
        public SupplierAndProductEntity FromDomainToEntity(SupplierAndProduct example)
        {
            return new SupplierAndProductEntity(example.ID, example.SupplierID, example.ProductID, example.Price);
        }

        public SupplierAndProduct FromEntityToDomain(SupplierAndProductEntity example)
        {
            return new SupplierAndProduct(example.ID, example.SupplierID, example.ProductID, example.Price);
        }
    }
}
