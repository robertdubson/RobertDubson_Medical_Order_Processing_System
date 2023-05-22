using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalDeliveryService.Models
{
    public class ClientCreationViewModel : PageModel
    {

        [BindNever]
        public List<City> CityModels { get; set; }

        public string SelectedCityIDStr { get; set; }

        public int CityID { get; set; }

        public string PasswordHash { get; set; }

        public string StrId { get; set; }

        public string Phone { get; set; }

        public string EMail { get; set; }

        public ClientCreationViewModel()
        {

        }

        public ClientCreationViewModel(List<City> allCities,string strId,  string realName, string userName, int cityId, string pasHahs, string phone, string mail)
        {
            AllCities = new List<SelectListItem>();

            allCities.ForEach(c => AllCities.Add(new SelectListItem(c.CityName, c.ID.ToString())));

            CityModels = allCities;

            OfficialName = realName;

            UserName = userName;

            CityID = cityId;

            PasswordHash = pasHahs;

            InsertedPassword = "";

            StrId = strId;

            Phone = phone;

            EMail = mail;
        }

        public ClientCreationViewModel(List<City> allCities)
        {

            AllCities = new List<SelectListItem>();

            allCities.ForEach(c => AllCities.Add(new SelectListItem(c.CityName, c.ID.ToString())));

            CityModels = allCities;
        }
        [BindNever]
        public List<SelectListItem> AllCities { get; set; }

        //public City SelectedCity { get { return CityModels.Find(c => c.ID == int.Parse(SelectedCityIDStr)); } }

        public string InsertedPassword { get; set; }

        public string UserName { get; set; }

        public string OfficialName { get; set; }



            
    }
}
