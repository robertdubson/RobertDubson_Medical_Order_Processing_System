using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class DeliveryCompanyGeneGenerator : IGeneGenerator<DeliveryCompanyGene>
    {
        List<DeliveryCompany> _companies;

        List<DeliveryCompanyAndCity> _deliveryCompanyAndCities;

        List<City> _cities;

        City _destination;

        List<DeliveryCompanyGene> _genes;

        int _maxCouriers;

        double _minDistance;

        double _minPrice;


        public DeliveryCompanyGeneGenerator(List<DeliveryCompany> companies, List<DeliveryCompanyAndCity> compAndCities, List<City> cities, City destination) 
        {
            _companies = companies;

            _deliveryCompanyAndCities = compAndCities;

            _cities = cities;

            _destination = destination;

            _genes = new List<DeliveryCompanyGene>();
        }

        private int FindMaxAvailableCouriers(List<DeliveryCompanyAndCity> companiesAndCities) 
        {
            int maxCouriers = 0;

            if (companiesAndCities.Count != 0) 
            {

                var randomDC = new Random();

                int index = randomDC.Next(companiesAndCities.Count);

                maxCouriers = companiesAndCities[index].AvailableCouriers;

                foreach (DeliveryCompanyAndCity dc in companiesAndCities)
                {
                    if (maxCouriers < dc.AvailableCouriers) 
                    {
                        maxCouriers = dc.AvailableCouriers;
                    }
                }

            }

            return maxCouriers;

        }

        private double FindMinDistance(List<City> cities, City destination) 
        {
            double minDistance = 0;

            cities.Remove(destination);

            if (cities.Count != 0)
            {
                Dictionary<City, double> distances = new Dictionary<City, double>();

                cities.ForEach(c => distances.Add(c, GetDistanceBetween(c, destination)));

                var random = new Random();

                int index = random.Next(distances.Keys.Count);

                minDistance = distances[cities[index]];

                foreach (City c in distances.Keys)
                {
                    if (distances[c] < minDistance & distances[c]!=0)
                    {
                        minDistance = distances[c];
                    }
                }
            }

            return minDistance;

        }

        private double GetDistanceBetween(City one, City two)
        {

            double distance = Math.Sqrt(Math.Pow(one.CoordinateX - two.CoordinateX, 2) + Math.Pow(one.CoordinateY - two.CoordinateY, 2));

            return distance;
        }

        private double FindMinPrice(List<DeliveryCompany> companies, List<City> cities, City destination) 
        {

            double minPrice = 0;

            var randomCity = new Random();

            int indexCity = randomCity.Next(cities.Count);

            var randomCompany = new Random();

            int indexCompany = randomCompany.Next(companies.Count);

            minPrice = companies[indexCompany].PriceForKm * GetDistanceBetween(cities[indexCity], destination);

            cities.Remove(destination);

            foreach (City c in cities)
            {
                foreach (DeliveryCompany dc in companies)
                {
                    if (minPrice > dc.PriceForKm * GetDistanceBetween(c, destination) & dc.PriceForKm * GetDistanceBetween(c, destination)!=0)
                    {
                        minPrice = dc.PriceForKm * GetDistanceBetween(c, destination);
                    }
                }
            }

            //minPrice = companies[indexCompany].PriceForKm;
            //foreach (DeliveryCompany company in companies) 
            //{
            //    if (company.PriceForKm<minPrice) 
            //    {
            //        minPrice = company.PriceForKm;
            //    }
            //}

            return minPrice;

        }
        
        public List<DeliveryCompanyGene> GenerateGenes()
        {
            _maxCouriers = FindMaxAvailableCouriers(_deliveryCompanyAndCities);

            _minDistance = FindMinDistance(_cities, _destination);

            _minPrice = FindMinPrice(_companies, _cities, _destination);

            
            
            foreach (DeliveryCompany c in _companies) 
            {
                foreach (City city in _cities) 
                {
                    DeliveryCompanyAndCity currentCompanyCity = _deliveryCompanyAndCities.Find(dc => dc.CompanyID == c.ID & dc.CityID == city.ID);

                    if (currentCompanyCity == null) 
                    {
                        currentCompanyCity = new DeliveryCompanyAndCity(c.ID, city.ID, 0);
                    }

                    _genes.Add(new DeliveryCompanyGene(c, currentCompanyCity, city, _destination, _maxCouriers, _minPrice, _minDistance));
                }
                
            }

            return _genes;
        }
    }
}
