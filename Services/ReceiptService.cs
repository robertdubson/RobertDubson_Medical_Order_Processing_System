using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Services.Abstract;
using BusinessLogic;
using DataLayer.UnitOfWork;
using Mappers;
namespace Services
{
    public class ReceiptService : IReceiptService
    {
        IUnitOfWork _unitOfWork;

        ReceiptMapper _receiptMapper;

        CityMapper _cityMapper;

        DeliveryCompanyMapper _deliveryCompanyMapper;

        DeliveryCompanyAndCityMapper _deliveryCompanyAndCityMapper;

        ProductAndFactoryMapper _productAndFactoryMapper;

        FactoryMapper _factoryMapper;

        SupplierAndProductMapper _supplierAndProductMapper;

        ReceiptAndProductMapper _receiptAndProductMapper;

        MedicalProductMapper _medicalProductMapper;

        public ReceiptService(IUnitOfWork uof)
        {
            _unitOfWork = uof;

            _receiptMapper = new ReceiptMapper();

            _cityMapper = new CityMapper();

            _deliveryCompanyMapper = new DeliveryCompanyMapper();

            _deliveryCompanyAndCityMapper = new DeliveryCompanyAndCityMapper();

            _productAndFactoryMapper = new ProductAndFactoryMapper();

            _factoryMapper = new FactoryMapper();

            _supplierAndProductMapper = new SupplierAndProductMapper();

            _receiptAndProductMapper = new ReceiptAndProductMapper();

            _medicalProductMapper = new MedicalProductMapper();
        }

        public void AddSolution(ReceiptAndProduct solution) 
        {
            _unitOfWork.ReceiptAndProductRepository.Add(_receiptAndProductMapper.NewExample(solution));
        }

        public void AddChainOfSolutions(City destination, List<MedicalProduct> purchasedProducts) 
        {
            foreach (ReceiptAndProduct rp in GenerateOptimizedReceipt(destination, purchasedProducts)) 
            {
                _unitOfWork.ReceiptAndProductRepository.Add(_receiptAndProductMapper.NewExample(rp));
                _unitOfWork.Complete();
            }
            
        }

        public List<ReceiptAndProduct> GenerateOptimizedReceipt(City destination, List<MedicalProduct> purchasedProducts)
        {
            List<ReceiptAndProduct> solutions = new List<ReceiptAndProduct>();

            foreach (MedicalProduct prod in purchasedProducts)
            {
                CityGeneGenerator cityGeneGenrator = new CityGeneGenerator(_unitOfWork.CityRepository.GetAll().ToList().Select(ct => _cityMapper.FromEntityToDomain(ct)).ToList(), destination);

                DeliveryCompanyGeneGenerator companyGenrator = new DeliveryCompanyGeneGenerator(_unitOfWork.DeliveryCompanyRepository.GetAll().Select(comp => _deliveryCompanyMapper.FromEntityToDomain(comp)).ToList(), _unitOfWork.CompanyAndCityRepository.GetAll().Select(cc => _deliveryCompanyAndCityMapper.FromEntityToDomain(cc)).ToList(), _unitOfWork.CityRepository.GetAll().ToList().Select(ct => _cityMapper.FromEntityToDomain(ct)).ToList(), destination);

                FactoryGeneGenerator factoryGenerator = new FactoryGeneGenerator(_unitOfWork.FactoryRepository.GetAll().Select(fc => _factoryMapper.FromEntityToDomain(fc)).ToList(), _unitOfWork.CityRepository.GetAll().ToList().Select(ct => _cityMapper.FromEntityToDomain(ct)).ToList(), _unitOfWork.ProductAndFactoryRepository.GetAll().Select(fp => (_productAndFactoryMapper.FromEntityToDomain(fp))).ToList(), _unitOfWork.SupplierAndProductRepository.GetAll().Select(sp => _supplierAndProductMapper.FromEntityToDomain(sp)).ToList(), prod, destination);

                ReceiptGeneticAlgorithm receiptGeneticAlgorithm = new ReceiptGeneticAlgorithm(prod, cityGeneGenrator, factoryGenerator, companyGenrator);

                ReceiptSolution solution = receiptGeneticAlgorithm.GetSolution();
                
                solutions.Add(new ReceiptAndProduct(_unitOfWork.ReceiptRepository.NextID(), prod.ID, solution.CityGene.GetCity().ID, solution.FactoryGene.GetFactory().ID, solution.CompanyGene.GetCompany().ID));

            }

            return solutions;
        }

        public void AddReceipt(Receipt receipt) 
        {
            receipt.CreationDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            _unitOfWork.ReceiptRepository.Add(_receiptMapper.NewExample(receipt));
            //_unitOfWork.Complete();
        }

        public void DeleteReceipt(int Id)
        {
            _unitOfWork.ReceiptRepository.Delete(Id);
        }

        public List<Receipt> GetAllReceipts()
        {
            return _unitOfWork.ReceiptRepository.GetAll().ToList().Select(rec => _receiptMapper.FromEntityToDomain(rec)).ToList();
        }

        public List<Receipt> GetAllReceiptsByDoctorId(int doctorId)
        {
            return _unitOfWork.ReceiptRepository.GetReceiptsByDoctorId(doctorId).ToList().Select(rec => _receiptMapper.FromEntityToDomain(rec)).ToList();
        }

        public Receipt GetReceiptById(int id)
        {
            return _receiptMapper.FromEntityToDomain(_unitOfWork.ReceiptRepository.GetByID(id));
        }

        public void UpdateReceipt(Receipt receipt)
        {
            _unitOfWork.ReceiptRepository.Update(_receiptMapper.FromDomainToEntity(receipt));
        }

        public List<MedicalProduct> GetPrescriptedProducts(int receiptId) 
        {
            return _unitOfWork.ReceiptAndProductRepository.GetPrescriptedProducts(receiptId).Select(pr => _medicalProductMapper.FromEntityToDomain(_unitOfWork.MedicalProductRepository.GetByID(pr.ProductID))).ToList();
        }
    }
}
