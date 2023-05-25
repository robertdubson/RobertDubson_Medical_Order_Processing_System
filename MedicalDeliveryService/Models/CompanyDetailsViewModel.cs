using BusinessLogic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDeliveryService.Models
{
    public class CompanyDetailsViewModel
    {
        public int ID { get; set; }

        public List<City> PossibleCities { get; set; }

        public List<SelectListItem> CityItems { get; set; }

        public DeliveryCompanyAndCity CurrentEntity { get; set; }

        public int CompanyID { get; set; }

        public int CityID { get; set; }

        public int WorkersAvailable { get; set; }

        public string CityName { get; set; }

        public string CompanyName { get; set; }

        public CompanyDetailsViewModel(DeliveryCompanyAndCity details, string cityName, string companyName)
        {
            ID = details.ID;

            CompanyID = details.CompanyID;

            CityID = details.CityID;

            WorkersAvailable = details.AvailableCouriers;

            CityName = cityName;

            CompanyName = companyName;
                
        }

        public CompanyDetailsViewModel(int companyID, int cityID, List<City> cities)
        {
            CompanyID = companyID;

            CityID = cityID;

            PossibleCities = cities;

            CityItems = new List<SelectListItem>();

            CityItems = PossibleCities.Select(ct => new SelectListItem(ct.CityName, ct.ID.ToString())).ToList();

        }

        public CompanyDetailsViewModel(int companyID, List<City> cities)
        {
            CompanyID = companyID;

            PossibleCities = cities;

            CityItems = new List<SelectListItem>();

            CityItems = PossibleCities.Select(ct => new SelectListItem(ct.CityName, ct.ID.ToString())).ToList();

        }

        public CompanyDetailsViewModel(int companyID, int cityID, int workers, List<City> cities)
        {
            WorkersAvailable = workers;

            CompanyID = companyID;

            CityID = cityID;

            PossibleCities = cities;

            CityItems = new List<SelectListItem>();

            CityItems = PossibleCities.Select(ct => new SelectListItem(ct.CityName, ct.ID.ToString())).ToList();

        }

        public CompanyDetailsViewModel(int Id, int companyID, int cityID, int workers, List<City> cities)
        {
            ID = Id;

            WorkersAvailable = workers;

            CompanyID = companyID;

            CityID = cityID;

            PossibleCities = cities;

            CityItems = new List<SelectListItem>();

            CityItems = PossibleCities.Select(ct => new SelectListItem(ct.CityName, ct.ID.ToString())).ToList();

        }
    }
}
