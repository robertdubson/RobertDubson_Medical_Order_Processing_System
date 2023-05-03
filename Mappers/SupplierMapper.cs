using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
using BusinessLogic;
namespace Mappers
{
    public class SupplierMapper : IMapper<SupplierEntity, Supplier>
    {
        public SupplierEntity FromDomainToEntity(Supplier example)
        {
            return new SupplierEntity(example.ID, example.Name);
        }

        public Supplier FromEntityToDomain(SupplierEntity example)
        {
            return new Supplier(example.ID, example.Name);
        }

        public SupplierEntity NewExample(Supplier example)
        {
            return new SupplierEntity( example.Name);
        }
    }
}
