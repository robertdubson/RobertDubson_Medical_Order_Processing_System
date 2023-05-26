using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.UnitOfWork;
using Mappers;
using System.Linq;
namespace Services.Abstract
{
    public class SupplierService : ISupplierService
    {
        IUnitOfWork _unitOfWork;

        SupplierMapper _supplierMapper;

        SupplierAndProductMapper _supplierAndProductMapper;

        FactoryMapper _factoryMapper;

        public SupplierService(IUnitOfWork uof, SupplierMapper mapper, SupplierAndProductMapper supplierAndProductMapper)
        {
            _unitOfWork = uof;

            _supplierMapper = mapper;

            _supplierAndProductMapper = supplierAndProductMapper;

            _factoryMapper = new FactoryMapper();


        }
        public void Add(Supplier example)
        {
            _unitOfWork.SupplierRepository.Add(_supplierMapper.FromDomainToEntity(example));
        }

        public void Delete(int id)
        {
            var factories = GetFactoriesBySupplier(id);
            var priceList = GetPriceList(id);

            if (factories.Count != 0) 
            {
                foreach (Factory f in factories) 
                {
                    _unitOfWork.FactoryRepository.Delete(f.ID);
                }
            }
            if (priceList.Count!=0) 
            {
                foreach (SupplierAndProduct sp in priceList) 
                {
                    DeleteSupplierAndProduct(sp.ID);
                }
            }

            _unitOfWork.SupplierRepository.Delete(id);
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _unitOfWork.SupplierRepository.GetAll().Select(sup => _supplierMapper.FromEntityToDomain(sup)).ToList();
        }

        public Supplier GetById(int id)
        {
            return _supplierMapper.FromEntityToDomain(_unitOfWork.SupplierRepository.GetByID(id));
        }

        public void Update(Supplier example)
        {
            _unitOfWork.SupplierRepository.Update(_supplierMapper.FromDomainToEntity(example));
        }

        public void DeleteSupplierAndProduct(int id) 
        {
            _unitOfWork.SupplierAndProductRepository.Delete(id);
        }

        public List<SupplierAndProduct> GetPriceList(int supplierId) 
        {
            return _unitOfWork.SupplierAndProductRepository.GetPriceList(supplierId).Select(sp => _supplierAndProductMapper.FromEntityToDomain(sp)).ToList();
        }

        public List<Factory> GetFactoriesBySupplier(int supplierId) 
        {
            return _unitOfWork.FactoryRepository.GetFactoriesBySupplierId(supplierId).Select(fac => _factoryMapper.FromEntityToDomain(fac)).ToList();
        }
    }
}
