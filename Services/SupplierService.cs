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

        public SupplierService(IUnitOfWork uof, SupplierMapper mapper, SupplierAndProductMapper supplierAndProductMapper)
        {
            _unitOfWork = uof;

            _supplierMapper = mapper;

            _supplierAndProductMapper = supplierAndProductMapper;
        }
        public void Add(Supplier example)
        {
            _unitOfWork.SupplierRepository.Add(_supplierMapper.FromDomainToEntity(example));
        }

        public void Delete(int id)
        {
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
    }
}
