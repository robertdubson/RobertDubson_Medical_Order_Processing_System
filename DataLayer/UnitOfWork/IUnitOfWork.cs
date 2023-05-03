using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Repositories;
using DataLayer.Repositories.Abstract;
namespace DataLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }

        IClientRepository ClientRepository { get; }

        ICompanyAndCityRepository CompanyAndCityRepository { get; }

        IDeliveryCompanyRepository DeliveryCompanyRepository { get; }

        IFactoryRepository FactoryRepository { get; }

        IIssuePointRepository IssuePointRepository { get; }

        IMedicalProductRepository MedicalProductRepository { get; }

        IProductAndFactoryRepository ProductAndFactoryRepository { get; }

        IReceiptAndProductRepository ReceiptAndProductRepository { get; }

        IReceiptRepository ReceiptRepository { get; }

        IStatusRepository StatusRepository { get; }

        ISupplierAndProductRepository SupplierAndProductRepository { get; }

        ISupplierRepository SupplierRepository { get; }

        IDoctorRepository DoctorRepository { get; }

        public int Complete();

    }
}
