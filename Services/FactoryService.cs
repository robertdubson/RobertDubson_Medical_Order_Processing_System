using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.UnitOfWork;
using BusinessLogic;
using Mappers;
using System.Linq;
using Services.Abstract;

namespace Services
{
    public class FactoryService : IFactoryService
    {
        IUnitOfWork _unitOfWork;

        FactoryMapper _factoryMapper;

        ProductAndFactoryMapper _productAndFactoryMapper;

        MedicalProductMapper _medicalProductMapper;

        public FactoryService(IUnitOfWork unitOfWork, FactoryMapper factoryMapper)
        {
            _unitOfWork = unitOfWork;
            _factoryMapper = factoryMapper;
            _productAndFactoryMapper = new ProductAndFactoryMapper();
            _medicalProductMapper = new MedicalProductMapper();

        }

        public List<Factory> GetAllFactories() 
        {
            return _unitOfWork.FactoryRepository.GetAll().Select(f => _factoryMapper.FromEntityToDomain(f)).ToList();
        }

        public void DeleteFactory(int ID) 
        {
            _unitOfWork.FactoryRepository.Delete(ID);
        }

        public void AddFactory(Factory factory) 
        {
            _unitOfWork.FactoryRepository.Add(_factoryMapper.NewExample(factory));
        }

        public void UpdateFactory(Factory factory) 
        {
            _unitOfWork.FactoryRepository.Update(_factoryMapper.FromDomainToEntity(factory));
        }

        public Factory GetFactory(int ID) 
        {
            return _factoryMapper.FromEntityToDomain(_unitOfWork.FactoryRepository.GetByID(ID));
        }

        public Dictionary<MedicalProduct, int> AvailableProducts(int Id) 
        {
            Dictionary<MedicalProduct, int> productAndUnits = new Dictionary<MedicalProduct, int>();

            //foreach (Factory f in GetAllFactories()) 
            //{
            //    List<ProductAndFactory> pAndF = _unitOfWork.ProductAndFactoryRepository.GetAll().Select(pf => _productAndFactoryMapper.FromEntityToDomain(pf)).ToList().FindAll(p => p.FactoryID==f.ID);
            //    foreach (ProductAndFactory pf in pAndF) 
            //    {
            //        if (pAndF.Find(example => example.FactoryID==f.ID & example.ProductID==pf.ProductID)!=null) 
            //        {
            //            productAndUnits[_medicalProductMapper.FromEntityToDomain(_unitOfWork.MedicalProductRepository.GetByID(pf.ProductID))] = pf.UnitsInStorage; 
            //        }
            //    }
            //}
            List<ProductAndFactory> pAndF = _unitOfWork.ProductAndFactoryRepository.GetAll().Select(pf => _productAndFactoryMapper.FromEntityToDomain(pf)).ToList().FindAll(p => p.FactoryID == Id);

            foreach (ProductAndFactory pf in pAndF) 
            {
                productAndUnits[_medicalProductMapper.FromEntityToDomain(_unitOfWork.MedicalProductRepository.GetByID(pf.ProductID))] = pf.UnitsInStorage;
            }


            return productAndUnits;
        }

        public void AddFactoryDetails(int FactoryId, int ProdId, int units) 
        {
            _unitOfWork.ProductAndFactoryRepository.Add(_productAndFactoryMapper.NewExample(new ProductAndFactory(_unitOfWork.ProductAndFactoryRepository.NextID(), FactoryId, ProdId, units)));
        }

        public void UpdateFactoryDetails(ProductAndFactory productAndFactory)
        {
            _unitOfWork.ProductAndFactoryRepository.Update(_productAndFactoryMapper.FromDomainToEntity(productAndFactory));
        }

        public List<ProductAndFactory> GetAllFactoryDetails()
        {
            return _unitOfWork.ProductAndFactoryRepository.GetAll().Select(pf => _productAndFactoryMapper.FromEntityToDomain(pf)).ToList();
        }

        public ProductAndFactory GetFactoryDetails(int Id)
        {
            return _productAndFactoryMapper.FromEntityToDomain(_unitOfWork.ProductAndFactoryRepository.GetByID(Id));
        }
    }
}
