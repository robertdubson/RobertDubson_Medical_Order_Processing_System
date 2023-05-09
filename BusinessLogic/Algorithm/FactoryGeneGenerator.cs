using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class FactoryGeneGenerator : IGeneGenerator<FactoryGene>
    {

        List<Factory> _factories;

        List<ProductAndFactory> _pAndFs;

        List<SupplierAndProduct> _priceInfo;

        List<City> _factoryCities;

        MedicalProduct _selectedProduct;

        City _destination;

        int _maxUnits;

        double _minDistance;

        double _minPrice;

        List<FactoryGene> _genes;


        public FactoryGeneGenerator(List<Factory> factories, List<City> cities, List<ProductAndFactory> productsInFactories, List<SupplierAndProduct> priceInfo, MedicalProduct selectedProduct, City destination) 
        {
            _factories = factories;

            _pAndFs = productsInFactories;

            _priceInfo = priceInfo;

            _destination = destination;

            _selectedProduct = selectedProduct;

            _factoryCities = cities;

            _genes = new List<FactoryGene>();
            
        }

        private int FindMaxUnits(List<ProductAndFactory> pAndFs, MedicalProduct selectedProduct) 
        {
            int maxUnits = 0;

            if (pAndFs.Count !=0) 
            {
                List<ProductAndFactory> clearedPAndFs = pAndFs.FindAll(p => p.ProductID == selectedProduct.ID);

                var random = new Random();

                int index = random.Next(clearedPAndFs.Count);

                maxUnits = clearedPAndFs[index].UnitsInStorage;

                foreach (ProductAndFactory pf in clearedPAndFs)
                {
                    if (pf.UnitsInStorage > maxUnits)
                    {
                        maxUnits = pf.UnitsInStorage;
                    }
                }
            }                       

            return maxUnits;
        }

        private double FindMinDistance(List<Factory> factories, List<City> cities, City destination) 
        {
            double min = 0;

            if (factories.Count != 0)
            {
                Dictionary<City, double> distances = new Dictionary<City, double>();

                foreach (Factory f in factories) 
                {
                    if (!distances.ContainsKey(cities.Find(c => c.ID == f.CityID))) 
                    {
                        distances.Add(cities.Find(c => c.ID == f.CityID), GetDistanceBetween(cities.Find(c => c.ID == f.CityID), destination));
                    }
                }

                //factories.ForEach(f => distances.Add(cities.Find(c => c.ID == f.CityID), GetDistanceBetween(cities.Find(c => c.ID == f.CityID), destination)));

                var random = new Random();

                int index = random.Next(distances.Keys.Count);

                City selectedCity = cities.Find(c => c.ID == factories[index].CityID);

                min = distances[selectedCity];

                foreach (City c in distances.Keys)
                {
                    if (distances[c] < min)
                    {
                        min = distances[c];
                    }
                }
            }

            return min;
            
        }



        private double FindMinPrice(MedicalProduct product, List<SupplierAndProduct> priceInfo) 
        {
            double minPrice = 0;

            if (priceInfo.Count != 0) 
            {
                List<SupplierAndProduct> clearedPriceInfo = priceInfo.FindAll(pI => pI.ProductID == product.ID);

                var random = new Random();

                int index = random.Next(clearedPriceInfo.Count);

                minPrice = clearedPriceInfo[index].Price;

                foreach (SupplierAndProduct sp in clearedPriceInfo) 
                {
                    if (sp.Price < minPrice) 
                    {
                        minPrice = sp.Price;
                    }
                }

            }

            return minPrice;
        }

        public List<FactoryGene> GenerateGenes()
        {
            _maxUnits = FindMaxUnits(_pAndFs, _selectedProduct);

            _minDistance = FindMinDistance(_factories, _factoryCities, _destination);

            _minPrice = FindMinPrice(_selectedProduct, _priceInfo);

            

            foreach (Factory f in _factories) 
            {
                SupplierAndProduct sAndP = _priceInfo.Find(pI => pI.ProductID == _selectedProduct.ID & pI.SupplierID == f.CompanyID);

                ProductAndFactory pAndF = _pAndFs.Find(pF => pF.ProductID == _selectedProduct.ID & f.ID == pF.FactoryID);

                if (pAndF==null) 
                {
                    pAndF = new ProductAndFactory(f.ID, _selectedProduct.ID, 0);
                }

                City factoryCity = _factoryCities.Find(c => c.ID == f.CityID);

                _genes.Add(new FactoryGene(f, factoryCity,_selectedProduct, sAndP, pAndF, _destination, _maxUnits, _minDistance, _minPrice));
            }

            return _genes;
        }

        private double GetDistanceBetween(City one, City two)
        {

            double distance = Math.Sqrt(Math.Pow(one.CoordinateX - two.CoordinateX, 2) - Math.Pow(one.CoordinateY - two.CoordinateY, 2));

            return distance;
        }
    }
}
