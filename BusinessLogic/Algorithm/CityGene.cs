using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class CityGene : IGene
    {

        City destinationCity;

        City currentCity;

        double minDistance;

        bool _geneValue;

        public CityGene(City _destinationCity, City _currentCity, double _minDistance) {

            destinationCity = _destinationCity;

            currentCity = _currentCity;

            minDistance = _minDistance;

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

        public City GetCity() 
        {
            return currentCity;
        }

        public double CalculateRank()
        {
            return minDistance / Math.Sqrt(Math.Pow((destinationCity.CoordinateX - currentCity.CoordinateX), 2d) + Math.Pow((destinationCity.CoordinateY - currentCity.CoordinateY), 2d));
        }
    }
}
