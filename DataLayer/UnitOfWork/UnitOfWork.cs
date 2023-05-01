using DataLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Repositories;
namespace DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationContext _db;

        private ICityRepository _cityRepository;
        private IClientRepository _clientRepository;
        private ICompanyAndCityRepository _companyAndCityRepository;
        private IDeliveryCompanyRepository _deliveryCompanyRepository;
        private IFactoryRepository _factoryRepository;
        private IIssuePointRepository _issuePointRepository;
        private IMedicalProductRepository _medicalProductRepository;
        private IProductAndFactoryRepository _productAndFactoryRepository;
        private IReceiptAndProductRepository _receiptAndProductRepository;
        private IReceiptRepository _receiptRepository;
        private IStatusRepository _statusRepository;
        private ISupplierAndProductRepository _supplierAndProductRepository;
        private ISupplierRepository _supplierRepository;

        public UnitOfWork(ApplicationContext db)
        {
            _db = db;
        }

        public ICityRepository CityRepository { get { return _cityRepository ??= new CityRepository(_db); } }

        public IClientRepository ClientRepository { get { return _clientRepository ??= new ClientRepository(_db); } }

        public ICompanyAndCityRepository CompanyAndCityRepository { get { return _companyAndCityRepository ??= new CompaniesAndCitiesRepository(_db); } }

        public IDeliveryCompanyRepository DeliveryCompanyRepository { get { return _deliveryCompanyRepository ??= new DeliveryCompanyRepository(_db); } }

        public IFactoryRepository FactoryRepository { get { return _factoryRepository ??= new FactoryRepository(_db); } }

        public IIssuePointRepository IssuePointRepository { get { return _issuePointRepository ??= new IssuePointRepository(_db); } }

        public IMedicalProductRepository MedicalProductRepository { get { return _medicalProductRepository ??= new MedicalProductRepository(_db); } }

        public IProductAndFactoryRepository ProductAndFactoryRepository { get { return _productAndFactoryRepository ??= new ProductAndFactoriesRepository(_db); } }

        public IReceiptAndProductRepository ReceiptAndProductRepository { get { return _receiptAndProductRepository ??= new ReceiptAndProductRepository(_db); } }

        public IReceiptRepository ReceiptRepository { get { return _receiptRepository ??= new ReceiptRepository(_db); } }

        public IStatusRepository StatusRepository { get { return _statusRepository ??= new StatusRepository(_db); } }

        public ISupplierAndProductRepository SupplierAndProductRepository { get { return _supplierAndProductRepository ??= new SupplierAndProductRepository(_db); } }

        public ISupplierRepository SupplierRepository { get { return _supplierRepository ??= new SupplierRepository(_db); } }

        public int Complete()
        {
            return _db.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
