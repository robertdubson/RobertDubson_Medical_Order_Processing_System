using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
namespace MedicalDeliveryService.Models
{
    public class FactoryDetailsViewModel
    {
        public int ProductAndFactoryID { get; set; }

        public MedicalProduct Product { get; set; }

        public int UnitsInStock { get; set; }

        public Factory Factory { get; set; }

        public int FactoryID { get; set; }

        public int ProductID { get; set; }

        public int ID { get; set; }

        public FactoryDetailsViewModel(int productAndFactoryId, Factory factory, MedicalProduct product, int units)
        {
            Factory = factory;

            Product = product;

            UnitsInStock = units;

            FactoryID = factory.ID;

            ProductID = Product.ID;

            ProductAndFactoryID = productAndFactoryId;
        }


    }
}
