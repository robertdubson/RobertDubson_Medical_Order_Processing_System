using BusinessLogic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDeliveryService.Models
{
    public class DoctorViewModel
    {
        public List<SelectListItem> PossibleCities { get; set; }

        public List<City> PosibbleCityModels { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Password { get; set; }

        public int LocationID { get; set; }

        public string EMail { get; set; }

        public string Phone { get; set; }

        public City City { get; set; }

        public DoctorViewModel(int id, string cname, string passwordHash, string username, string phone, string email, List<City> cities)
        {
            ID = id;

            UserName = username;

            PasswordHash = passwordHash;

            Name = cname;

            Phone = phone;

            EMail = email;

            PosibbleCityModels = cities;

            PossibleCities = new List<SelectListItem>();

            cities.ForEach(c => PossibleCities.Add(new SelectListItem(c.CityName, c.ID.ToString())));
        }

        public DoctorViewModel(List<City> cities) 
        {
            PosibbleCityModels = cities;

            PossibleCities = new List<SelectListItem>();

            cities.ForEach(c => PossibleCities.Add(new SelectListItem(c.CityName, c.ID.ToString())));

        }

        public DoctorViewModel(int id, City city, string cname, string passwordHash, string username, string phone, string email, List<City> cities)
        {
            ID = id;

            UserName = username;

            PasswordHash = passwordHash;

            Name = cname;

            Phone = phone;

            EMail = email;

            PosibbleCityModels = cities;

            City = city;

            PossibleCities = new List<SelectListItem>();

            cities.ForEach(c => PossibleCities.Add(new SelectListItem(c.CityName, c.ID.ToString())));
        }

        public DoctorViewModel(string cname, string passwordHash, string username)
        {

            UserName = username;

            PasswordHash = passwordHash;

            Name = cname;
        }
    }
}
