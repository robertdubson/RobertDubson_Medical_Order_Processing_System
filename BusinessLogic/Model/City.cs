using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class City : BaseModel
    {

        //public int ID { get; private set; }

        public string CityName { get; set; }

        public double CoordinateX { get; set; }

        public double CoordinateY { get; set; }

        public City(int iD, string cityName, double X, double Y) 
        {
            ID = iD;

            CityName = cityName;

            CoordinateX = X;

            CoordinateY = Y;

        }

        public City(string cityName, double X, double Y)
        {

            CityName = cityName;

            CoordinateX = X;

            CoordinateY = Y;            

        }

        public override string ToString()
        {
            return CityName;
        }
    }
}
