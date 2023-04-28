using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Supplier : BaseModel
    {

        public string Name { get; set; }

        public Supplier(int id, string name)
        {
            ID = id;

            Name = name;
        }

        public Supplier(string name) 
        {
            Name = name;
        }
        
    }
}
