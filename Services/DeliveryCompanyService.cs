using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using Services.Abstract;
using DataLayer.UnitOfWork;
using DataLayer.Repositories;
using Mappers;
using System.Linq;
namespace Services
{
    public class DeliveryCompanyService : IDeliveryCompanyService
    {
        IUnitOfWork _unitOfWork;

        DeliveryCompanyAndCityMapper _deliveryCompanyAndCityMapper;

        DeliveryCompanyMapper _deliveryCompanyMapper;

        public DeliveryCompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _deliveryCompanyAndCityMapper = new DeliveryCompanyAndCityMapper();

            _deliveryCompanyMapper = new DeliveryCompanyMapper();
        }
        public void AddCompany(DeliveryCompany company)
        {
            _unitOfWork.DeliveryCompanyRepository.Add(_deliveryCompanyMapper.NewExample(company));
        }

        public void AddWorkersToCity(DeliveryCompanyAndCity companyDetails)
        {
            _unitOfWork.CompanyAndCityRepository.Add(_deliveryCompanyAndCityMapper.NewExample(companyDetails));
        }

        public void DeletDeliveryCompany(int Id)
        {
            _unitOfWork.DeliveryCompanyRepository.Delete(Id);
        }

        public void DeleteAllWorkersFromCity(int companyDetailsId)
        {
            _unitOfWork.CompanyAndCityRepository.Delete(companyDetailsId);
        }

        public List<DeliveryCompany> GetAllCompanies()
        {
            return _unitOfWork.DeliveryCompanyRepository.GetAll().Select(cm => _deliveryCompanyMapper.FromEntityToDomain(cm)).ToList();
        }

        public DeliveryCompany GetById(int id)
        {
            return _deliveryCompanyMapper.FromEntityToDomain(_unitOfWork.DeliveryCompanyRepository.GetByID(id));
        }

        public List<DeliveryCompanyAndCity> GetCompanyDetails(int CompanyId)
        {
            return _unitOfWork.CompanyAndCityRepository.GetCompanyDetails(CompanyId).Select(dt => _deliveryCompanyAndCityMapper.FromEntityToDomain(dt)).ToList();
        }

        public DeliveryCompanyAndCity GetDetailsById(int Id)
        {
            return _deliveryCompanyAndCityMapper.FromEntityToDomain(_unitOfWork.CompanyAndCityRepository.GetByID(Id));
        }

        public void UpdateDeliveryCompany(DeliveryCompany example)
        {
            _unitOfWork.DeliveryCompanyRepository.Update(_deliveryCompanyMapper.FromDomainToEntity(example));
        }

        public void UpdateCompanyDetail(DeliveryCompanyAndCity companyDetails)
        {
            _unitOfWork.CompanyAndCityRepository.Update(_deliveryCompanyAndCityMapper.FromDomainToEntity(companyDetails));
        }
    }
}
