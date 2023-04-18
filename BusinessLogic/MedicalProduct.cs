using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class MedicalProduct
    {
        public string ProductName { get; set; }

        public string Description { get; set; }

        public string InstructionToUse { get; set; }

        public float Price { get; set; }

        public Supplier ProductSupplier { get; set; }

        
    }
}
