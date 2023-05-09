using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ProductAndFactory : BaseModel
    {

        public int FactoryID { get; set; }

        public int ProductID { get; set; }

        public int UnitsInStorage { get; set; }

        public ProductAndFactory(int id, int factoryId, int productId, int unitsInStorage)
        {
            ID = id;

            FactoryID = factoryId;

            ProductID = productId;

            UnitsInStorage = unitsInStorage;
        }

        public ProductAndFactory(int factoryId, int productId, int unitsInStorage)
        {

            FactoryID = factoryId;

            ProductID = productId;

            UnitsInStorage = unitsInStorage;
        }
    }
}
