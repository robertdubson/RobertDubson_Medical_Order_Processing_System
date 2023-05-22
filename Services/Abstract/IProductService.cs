using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
namespace Services.Abstract
{
    public interface IProductService
    {

        public List<MedicalProduct> GetAllProducts();

        public void UpdateProduct(MedicalProduct product);
        public void DeleteProduct(int ID);

        public MedicalProduct GetProduct(int ID);
        public void AddProductAndFactory(int IdProduct, int IdFactory, int units);

        public void AddProduct(MedicalProduct product);

        public double GetPrice(int factoryId, int productId);

    }
}
