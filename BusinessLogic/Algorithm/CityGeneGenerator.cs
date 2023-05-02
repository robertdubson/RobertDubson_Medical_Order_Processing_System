using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class CityGeneGenerator : IGeneGenerator<CityGene>
    {

        List<CityGene> _genes;

        List<City> _cities;

        City _destination;

        double _minDistance;

        public CityGeneGenerator(List<City> cities, City destination) 
        {

            _genes = new List<CityGene>();

            _destination = destination;

            _cities = cities;
        }

        private double FindMinDistance(List<City> cities, City destination) 
        {

            double min = 0;
            
            if (cities.Count != 0) 
            {
                Dictionary<City, double> distances = new Dictionary<City, double>();

                cities.ForEach(c => distances.Add(c, GetDistanceBetween(c, destination)));

                var random = new Random();

                int index = random.Next(distances.Keys.Count);

                min = distances[cities[index]];

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

        private double GetDistanceBetween(City one, City two) 
        {

            double distance = Math.Sqrt(Math.Pow(one.CoordinateX - two.CoordinateX, 2) - Math.Pow(one.CoordinateY - two.CoordinateY, 2));

            
            return distance;
        }

        public List<CityGene> GenerateGenes()
        {
            _minDistance = FindMinDistance(_cities, _destination);

            foreach (City c in _cities)
            {
                _genes.Add(new CityGene(_destination, c, _minDistance));
            }

            return _genes;
        }
    }
}
