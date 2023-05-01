using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class DeliveryCompanyGene : IGene
    {

        DeliveryCompany _currentCompany;

        DeliveryCompanyAndCity _cityData;

        double _minPriceForDelivery;

        double _minDistance;

        int _maxAvailableCouriers;

        City _destination;

        City _currentCity;

        bool _geneValue;

        public DeliveryCompanyGene(DeliveryCompany currentCompany, DeliveryCompanyAndCity cityData, City currentCity, City destination, int maxCouriers, double minPrice, double minDistance) 
        {
            _currentCompany = currentCompany;

            _cityData = cityData;

            _minPriceForDelivery = minPrice;

            _destination = destination;

            _maxAvailableCouriers = maxCouriers;

            _minDistance = minDistance;

            _currentCity = currentCity;

            _geneValue = false;

        }

        public bool IsSelected() 
        {
            return _geneValue;
        }

        public void SelectGene() 
        {
            _geneValue = true;
        }        

        public void UnselectGene()
        {
            _geneValue = false;
        }

        public DeliveryCompany GetCompany() 
        {
            return _currentCompany;
        }

        public double CalculateRank()
        {

            double currentDistance = Math.Sqrt(Math.Pow(_destination.CoordinateX - _currentCity.CoordinateX, 2) - Math.Pow(_destination.CoordinateY - _currentCity.CoordinateY, 2));

            double distanceRank = _minDistance / currentDistance;

            double priceRank = _minPriceForDelivery * _minDistance / _currentCompany.PriceForKm / currentDistance;

            double availableWorkersRank = _cityData.AvailableCouriers / _maxAvailableCouriers;
            
            return (distanceRank + priceRank + availableWorkersRank) / 3;
        }
    }
}
