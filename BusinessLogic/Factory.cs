using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Factory
    {
        
        public int ID { get; private set; }
        
        public City Location { get; set; }

        public string Address { get; set; }

        public void OrderAProduct(int _productId) 
        { }

    }
}
