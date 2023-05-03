using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class ProductAndFactoryEntity : BaseEntity
    {
        public int FactoryID { get; set; }

        public int ProductID { get; set; }

        public int UnitsInStorage { get; set; }

        public ProductAndFactoryEntity(int id, int factoryId, int productId, int unitsInStorage)
        {
            ID = id;

            FactoryID = factoryId;

            ProductID = productId;

            UnitsInStorage = unitsInStorage;
        }

        public ProductAndFactoryEntity(int factoryId, int productId, int unitsInStorage)
        {

            FactoryID = factoryId;

            ProductID = productId;

            UnitsInStorage = unitsInStorage;
        }

        public ProductAndFactoryEntity()
        {

        }
    }
}
