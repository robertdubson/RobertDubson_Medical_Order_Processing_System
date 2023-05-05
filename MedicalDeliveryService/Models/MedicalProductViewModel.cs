using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
namespace MedicalDeliveryService.Models
{
    public class MedicalProductViewModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }

        public string Description { get; set; }

        public string InstructionToUse { get; set; }

        public MedicalProductViewModel(int id, string prodName, string description, string instruction)
        {
            ID = id;

            ProductName = prodName;

            Description = description;

            InstructionToUse = instruction;
        }
    }
}
