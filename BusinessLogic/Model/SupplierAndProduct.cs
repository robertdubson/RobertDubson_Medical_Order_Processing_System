using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class SupplierAndProduct : BaseModel
    {

        public int SupplierID { get; set; }

        public int ProductID { get; set; }

        public double Price { get; set; }

        public SupplierAndProduct(int id, int SupId, int ProdId, double price)
        {
            ID = id;

            SupplierID = SupId;

            ProductID = ProdId;

            Price = price;
        }
    }
}
