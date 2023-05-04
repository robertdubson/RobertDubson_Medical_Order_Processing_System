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
    }
}
