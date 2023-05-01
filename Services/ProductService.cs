using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.UnitOfWork;
using Mappers;
using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        private MedicalProductMapper _productMapper;

        public ProductService(IUnitOfWork uof, MedicalProductMapper mapper)
        {
            _unitOfWork = uof;

            _productMapper = mapper;
        }

        public List<MedicalProduct> GetAllProducts() 
        {
            return _unitOfWork.MedicalProductRepository.GetAll().Select(pr => _productMapper.FromEntityToDomain(pr)).ToList();
        }

        public void UpdateProduct(MedicalProduct product) 
        {
            _unitOfWork.MedicalProductRepository.Update(_productMapper.FromDomainToEntity(product));
        }

        public void DeleteProduct(int ID) 
        {
            _unitOfWork.MedicalProductRepository.Delete(ID);
        }

        public MedicalProduct GetProduct(int ID) 
        {
            return _productMapper.FromEntityToDomain(_unitOfWork.MedicalProductRepository.GetByID(ID));
        }


    }
}
