using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using DataModel;
namespace Mappers
{
    public class ProductAndFactoryMapper : IMapper<ProductAndFactoryEntity, ProductAndFactory>
    {
        public ProductAndFactoryEntity FromDomainToEntity(ProductAndFactory example)
        {
            return new ProductAndFactoryEntity(example.ID, example.FactoryID, example.ProductID, example.UnitsInStorage);
        }

        public ProductAndFactory FromEntityToDomain(ProductAndFactoryEntity example)
        {
            return new ProductAndFactory(example.ID, example.FactoryID, example.ProductID, example.UnitsInStorage);
        }

        public ProductAndFactoryEntity NewExample(ProductAndFactory example)
        {
            return new ProductAndFactoryEntity(example.FactoryID, example.ProductID, example.UnitsInStorage);
        }
    }
}
