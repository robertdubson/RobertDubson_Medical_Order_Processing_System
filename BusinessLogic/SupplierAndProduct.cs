using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class SupplierAndProduct
    {
        public int ID { get; private set; }

        public int SupplierID { get; set; }

        public int ProductID { get; set; }

        public double Price { get; set; }
    }
}
