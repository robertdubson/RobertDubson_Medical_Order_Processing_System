using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class MedicalProduct : BaseModel
    {

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string InstructionToUse { get; set; }

        public double Price { get; set; }

        public MedicalProduct(int id, string prodName, string description, string instruction)
        {
            ID = id;

            ProductName = prodName;

            Description = description;

            InstructionToUse = instruction;
        }

        public MedicalProduct(string prodName, string description, string instruction)
        {
            ProductName = prodName;

            Description = description;

            InstructionToUse = instruction;
        }

        
    }
}
