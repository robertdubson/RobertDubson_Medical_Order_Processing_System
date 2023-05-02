using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class CityEntity : BaseEntity
    {
        public string CityName { get; set; }

        public double CoordinateX { get; set; }

        public double CoordinateY { get; set; }

        public CityEntity()
        {

        }

        public CityEntity(int iD, string cityName, double X, double Y)
        {
            ID = iD;

            CityName = cityName;

            CoordinateX = X;

            CoordinateY = Y;

        }

        public CityEntity(string cityName, double X, double Y)
        {

            CityName = cityName;

            CoordinateX = X;

            CoordinateY = Y;

        }

    }
}
