using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class MedicalProductEntity : BaseEntity
    {
        public string ProductName { get; set; }

        public string Description { get; set; }

        public string InstructionToUse { get; set; }

        public MedicalProductEntity(int id, string prodName, string description, string instruction)
        {
            ID = id;

            ProductName = prodName;

            Description = description;

            InstructionToUse = instruction;
        }
    }
}
