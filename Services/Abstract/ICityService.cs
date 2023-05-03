using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
namespace Services.Abstract
{
    public interface ICityService
    {
        public List<City> GetAllCities();

        public List<DeliveryCompanyAndCity> GetAllCompanyAndCity();

        public City GetCityById(int Id);


    }
}
