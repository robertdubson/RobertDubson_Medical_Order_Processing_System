using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
namespace Services.Abstract
{
    public interface IFactoryService
    {
        public List<Factory> GetAllFactories();

        public void DeleteFactory(int ID);

        public void AddFactory(Factory factory);

        public void UpdateFactory(Factory factory);

        public Factory GetFactory(int ID);

        public Dictionary<MedicalProduct, int> AvailableProducts(int Id);

        public List<ProductAndFactory> GetAllFactoryDetails();

        public void AddFactoryDetails(int FactoryId, int ProdId, int units);

        public void UpdateFactoryDetails(ProductAndFactory productAndFactory);

        public ProductAndFactory GetFactoryDetails(int Id);
    }
}
