using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class FactoryGene : IGene
    {
        Factory _currentFactory;

        ProductAndFactory _dataAboutUnits;

        int _maxUnits;

        City _destination;

        double _minDistance;

        MedicalProduct _currentProduct;

        double _minPrice;

        SupplierAndProduct _priceInfo;



        // передавати фабрику і productandfactory тієї самої ID фабрики виключно
        public FactoryGene(Factory currentFactory, MedicalProduct currentProduct, SupplierAndProduct priceInfo, ProductAndFactory pAndF, City destination, int maxUnits, double minDistance, double minimalPrice) 
        {
            _currentFactory = currentFactory;

            _dataAboutUnits = pAndF;

            _maxUnits = maxUnits;

            _destination = destination;

            _minDistance = minDistance;

            _currentProduct = currentProduct;

            _priceInfo = priceInfo;

            _minPrice = minimalPrice;
        }

        public double CalculateRank()
        {
            double distance = Math.Sqrt(Math.Pow(_currentFactory.Location.CoordinateX - _destination.CoordinateX, 2) - Math.Pow(_currentFactory.Location.CoordinateY - _destination.CoordinateY, 2));
            
            double distance_rate = _minDistance / distance;
            
            double price_rate = _minPrice / _priceInfo.Price;
            
            double units_rate = _dataAboutUnits.UnitsInStorage / _maxUnits;
            
            double overall_rate = (distance_rate + price_rate + units_rate) / 3;
            
            return overall_rate;
        }
    }
}
