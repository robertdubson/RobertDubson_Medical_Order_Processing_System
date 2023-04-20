using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ProductAndFactory
    {
        public int ID { get; private set; }

        public int FactoryID { get; set; }

        public int ProductID { get; set; }

        public int UnitsInStorage { get; set; }
    }
}
