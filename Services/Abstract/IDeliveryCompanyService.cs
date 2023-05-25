using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
namespace Services.Abstract
{
    public interface IDeliveryCompanyService
    {
        List<DeliveryCompany> GetAllCompanies();

        void UpdateDeliveryCompany(DeliveryCompany example);

        void DeletDeliveryCompany(int Id);

        void AddCompany(DeliveryCompany company);

        List<DeliveryCompanyAndCity> GetCompanyDetails(int CompanyId);

        void AddWorkersToCity(DeliveryCompanyAndCity companyDetails);

        void DeleteAllWorkersFromCity(int companyDetailsId);

        void UpdateCompanyDetail(DeliveryCompanyAndCity companyDetails);

        DeliveryCompany GetById(int id);

        DeliveryCompanyAndCity GetDetailsById(int Id);


    }
}
