using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.UnitOfWork;
using BusinessLogic;
using Mappers;
using System.Linq;
namespace Services
{
    public class FactoryService
    {
        IUnitOfWork _unitOfWork;

        FactoryMapper _factoryMapper;

        public FactoryService(IUnitOfWork unitOfWork, FactoryMapper factoryMapper)
        {
            _unitOfWork = unitOfWork;
            _factoryMapper = factoryMapper;
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
            _unitOfWork.FactoryRepository.Add(_factoryMapper.FromDomainToEntity(factory));
        }

        public void UpdateFactory(Factory factory) 
        {
            _unitOfWork.FactoryRepository.Update(_factoryMapper.FromDomainToEntity(factory));
        }

        public Factory GetFactory(int ID) 
        {
            return _factoryMapper.FromEntityToDomain(_unitOfWork.FactoryRepository.GetByID(ID));
        }
    }
}
