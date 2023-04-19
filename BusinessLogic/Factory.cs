using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Factory
    {
        public City Location { get; set; }

        public List<MedicalProduct> AvailableProducts { get; set; }

        public void OrderAProduct(int _productId) 
        { }

        public List<Worker> AvailableWorkers;

    }
}
