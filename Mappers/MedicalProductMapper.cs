using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using DataModel;
namespace Mappers
{
    public class MedicalProductMapper : IMapper<MedicalProductEntity, MedicalProduct>
    {
        public MedicalProductEntity FromDomainToEntity(MedicalProduct example)
        {
            return new MedicalProductEntity(example.ID, example.ProductName, example.Description, example.InstructionToUse);
        }

        public MedicalProduct FromEntityToDomain(MedicalProductEntity example)
        {
            return new MedicalProduct(example.ID, example.ProductName, example.Description, example.InstructionToUse);
        }

        public MedicalProductEntity NewExample(MedicalProduct example)
        {
            return new MedicalProductEntity(example.ProductName, example.Description, example.InstructionToUse);
        }
    }
}
