using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.UnitOfWork;
using Mappers;
using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Services.Abstract;
namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        private MedicalProductMapper _productMapper;

        private ProductAndFactoryMapper _productAndFactoryMapper;

        public ProductService(IUnitOfWork uof, MedicalProductMapper mapper, ProductAndFactoryMapper productAndFactoryMapper )
        {
            _unitOfWork = uof;

            _productMapper = mapper;

            _productAndFactoryMapper = productAndFactoryMapper;
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

        public void AddProductAndFactory(int IdProduct, int IdFactory, int units) 
        {
            _unitOfWork.ProductAndFactoryRepository.Add(_productAndFactoryMapper.NewExample(new ProductAndFactory(_unitOfWork.ProductAndFactoryRepository.NextID(), IdFactory, IdProduct, units)));
        }

        public void AddProduct(MedicalProduct product)
        {
            _unitOfWork.MedicalProductRepository.Add(_productMapper.NewExample(product));
        }
    }
}
