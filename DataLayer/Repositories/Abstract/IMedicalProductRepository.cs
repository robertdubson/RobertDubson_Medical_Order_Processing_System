using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace DataLayer.Repositories.Abstract
{
    public interface IMedicalProductRepository : IRepository<MedicalProductEntity, int>
    {
        double GetPrice(int FactoryId);
    }
}
