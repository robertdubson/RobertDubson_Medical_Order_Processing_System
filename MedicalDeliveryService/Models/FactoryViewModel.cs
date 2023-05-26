using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MedicalDeliveryService.Models
{
    public class FactoryViewModel
    {
        public string FactoryId { get; set; }

        public string SupplierStr { get; set; }

        public string CityStr { get; set; }

        public int CityID { get; set; }

        public int CompanyID { get; set; }

        public int ID { get; set; }

        public City City { get; set; }

        public Supplier Supplier { get; set; }

        public string Address { get; set; }

        public List<City> PossibleCities { get; set; }

        public List<Supplier> PossibleSuppliers { get; set; }

        public List<SelectListItem> CityItems { get; set; }

        public List<SelectListItem> SupplierItems { get; set; }

        public FactoryViewModel(List<City> possibleCities, List<Supplier> possibleSuppliers)
        {
            PossibleCities = possibleCities;
            PossibleSuppliers = possibleSuppliers;
            CityItems = possibleCities.Select(ct => new SelectListItem(ct.CityName, ct.ID.ToString())).ToList();
            SupplierItems = possibleSuppliers.Select(sp => new SelectListItem(sp.Name, sp.ID.ToString())).ToList();
        }

        public FactoryViewModel(int Id, int cityID, string address, int companyID, List<City> possibleCities, List<Supplier> possibleSuppliers)
        {
            ID = Id;
            CityID = cityID;
            Address = address;
            CompanyID = companyID;
            PossibleCities = possibleCities;
            PossibleSuppliers = possibleSuppliers;
            CityItems = possibleCities.Select(ct => new SelectListItem(ct.CityName, ct.ID.ToString())).ToList();
            SupplierItems = possibleSuppliers.Select(sp => new SelectListItem(sp.Name, sp.ID.ToString())).ToList();
            FactoryId = Id.ToString();
        }

        public FactoryViewModel(int iD, City city, Supplier supplier, string address)
        {
            ID = iD;
            City = city;
            Supplier = supplier;
            Address = address;
            CompanyID = Supplier.ID;
            CityID = City.ID;
            FactoryId = iD.ToString();
        }

        public FactoryViewModel(int iD, City city, Supplier supplier, string address, List<City> possibleCities, List<Supplier> possibleSuppliers)
        {
            ID = iD;
            City = city;
            Supplier = supplier;
            Address = address;
            CompanyID = Supplier.ID;
            CityID = City.ID;
            FactoryId = iD.ToString();
            PossibleCities = possibleCities;
            PossibleSuppliers = possibleSuppliers;
            CityItems = possibleCities.Select(ct => new SelectListItem(ct.CityName, ct.ID.ToString())).ToList();
            SupplierItems = possibleSuppliers.Select(sp => new SelectListItem(sp.Name, sp.ID.ToString())).ToList();
        }
    }
}
