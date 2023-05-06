using System;
using DataLayer.UnitOfWork;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using DataModel;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.IO;
using MathNet.Numerics;
using System.Linq;
using MathNet.Numerics.Distributions;

namespace DataInizialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            UnitOfWork uof = new UnitOfWork(new ApplicationContext());

            List<string> addresses = new List<string>() { "Poshtovy avenue 16", "Nahirna 22", "Haharina 51", "Chernyahovskogo 33", "Vygovskogo 42" };

            List<int> couriers = new List<int>() {0, 5, 10, 15, 20, 30, 40, 45, 50, 60, 70, 80, 90, 100, 130, 150, 200, 230, 250, 300 };

            List<int> productInStock = new List<int>() {110, 120, 130, 140, 145, 150, 160, 200, 210, 250, 260, 300, 450, 460, 500, 1000, 2000, 3000, 4000, 5500, 5469, 5674, 65743, 86959, 548549, 13435, 56278, 345738, 2472753 };

            //uof.DoctorRepository.Add(new DoctorEntity("Robert Dubson", "1234567", "rodubson"));
            //uof.DoctorRepository.Add(new DoctorEntity("Willy Wonka", "1234567", "wonkawi"));
            //uof.DoctorRepository.Add(new DoctorEntity("Otto Octavius", "1234567", "octopus"));

            //uof.Complete();

            //int N = 100;
            //double mean = N / 2.0; // mean value
            //double stdDev = N / 10.0; // standard deviation

            //Normal normalDist = new Normal(mean, stdDev);

            //foreach (MedicalProductEntity med in uof.MedicalProductRepository.GetAll().ToList()) 
            //{
            //    foreach (SupplierEntity sup in uof.SupplierRepository.GetAll().ToList()) 
            //    {
            //        int value = (int)Math.Round(normalDist.Sample());
            //        value = Math.Max(0, Math.Min(N - 1, value));
            //        uof.SupplierAndProductRepository.Add(new SupplierAndProductEntity(sup.ID, med.ID, value));
            //    }
            //}
            //uof.Complete();

            //uof.MedicalProductRepository.Add(new MedicalProductEntity("CONCERTA", "Concerta is a central nervous system stimulant prescription medicine. It affects chemicals in the brain and nerves that contribute to hyperactivity and impulse control.", ""));

            //uof.Complete();

            //foreach (FactoryEntity factory in uof.FactoryRepository.GetAll().ToList()) 
            //{
            //    foreach (MedicalProductEntity med in uof.MedicalProductRepository.GetAll().ToList()) 
            //    {
            //        int value = (int)Math.Round(normalDist.Sample());
            //        value = Math.Max(0, Math.Min(N - 1, value));

            //        Console.WriteLine(factory.ID + " " + med.ProductName + " " + value);

            //        uof.ProductAndFactoryRepository.Add(new ProductAndFactoryEntity(factory.ID, med.ID, value));
            //    }
            //}
            //uof.Complete();
            //for (int i = 0; i < 10; i++)
            //{
            //    int value = (int)Math.Round(normalDist.Sample());
            //    value = Math.Max(0, Math.Min(N - 1, value)); // ensure value is within range
            //    Console.WriteLine($"Sample {i + 1}: {value}");
            //}

            //foreach (DeliveryCompanyEntity dc in uof.DeliveryCompanyRepository.GetAll().ToList())  
            //{
            //    foreach (CityEntity city in uof.CityRepository.GetAll().ToList()) 
            //    {
            //        Random rand = new Random();

            //        uof.CompanyAndCityRepository.Add(new DeliveryCompanyAndCityEntity(dc.ID, city.ID, couriers[rand.Next(couriers.Count)]));
            //    }
            //}
            //uof.Complete();

            //uof.DeliveryCompanyRepository.Add(new DeliveryCompanyEntity("Yamato", 0.3));
            //uof.DeliveryCompanyRepository.Add(new DeliveryCompanyEntity("TFI International ", 0.5));
            //uof.DeliveryCompanyRepository.Add(new DeliveryCompanyEntity("SF Express ", 0.7));
            //uof.DeliveryCompanyRepository.Add(new DeliveryCompanyEntity("Deutsche Post ", 0.9));
            //uof.DeliveryCompanyRepository.Add(new DeliveryCompanyEntity("UkrPoshta", 0.5));
            //uof.DeliveryCompanyRepository.Add(new DeliveryCompanyEntity("Nova Poshta", 0.6));

            //uof.Complete();

            //uof.CityRepository.Add(new CityEntity("Kyiv", 30.5233, 50.4500));
            //uof.CityRepository.Add(new CityEntity("Kharkiv",36.2311, 49.9925));
            //uof.CityRepository.Add(new CityEntity("Odesa", 30.7326, 46.4775));
            //uof.CityRepository.Add(new CityEntity("Dnipro", 35.0400, 48.4675));
            //uof.CityRepository.Add(new CityEntity("Donetsk", 30.5233, 50.4500));
            //uof.CityRepository.Add(new CityEntity("Zaporizhzhia", 35.1175, 47.8500));
            //uof.CityRepository.Add(new CityEntity("Lviv", 24.0322, 49.8425));
            //uof.CityRepository.Add(new CityEntity("Kryvyi Rih", 33.3433, 47.9086));
            //uof.CityRepository.Add(new CityEntity("Sevastopol", 33.5225, 44.6050));
            //uof.CityRepository.Add(new CityEntity("Mykolaiv", 31.9950, 46.9750));
            //uof.CityRepository.Add(new CityEntity("Kryvyi Rih", 33.3433, 47.9086));
            //uof.CityRepository.Add(new CityEntity("Kryvyi Rih", 33.3433, 47.9086));
            //uof.CityRepository.Add(new CityEntity("Kryvyi Rih", 33.3433, 47.9086));
            //uof.CityRepository.Add(new CityEntity("Kryvyi Rih", 33.3433, 47.9086));

            //using (TextFieldParser parser = new TextFieldParser("C:/Users/Robert/source/repos/RobertDubson_Medical_Order_Processing_System/RobertDubson_Medical_Order_Processing_System/worldcities.csv"))
            //{
            //    parser.TextFieldType = FieldType.Delimited;
            //    parser.SetDelimiters(",");

            //    // Read the headers to determine the index of each column
            //    string[] headers = parser.ReadFields();
            //    int column1Index = Array.IndexOf(headers, "city");
            //    int column2Index = Array.IndexOf(headers, "lng");
            //    int column3Index = Array.IndexOf(headers, "lat");
            //    int column4Index = Array.IndexOf(headers, "country");

            //    // Loop through the remaining lines in the file and extract the specified columns
            //    while (!parser.EndOfData)
            //    {
            //        string[] fields = parser.ReadFields();

            //        string column1 = fields[column1Index];
            //        string column2 = fields[column2Index];
            //        string column3 = fields[column3Index];
            //        string column4 = fields[column4Index];

            //        // Do something with the extracted columns, such as adding them to a list or database
            //        if (column4 == "Ukraine") 
            //        {
            //            //Console.WriteLine($"{column1}, {column2}, {column3}");
            //            string lat = column3.Replace(".", ",");
            //            string lng = column2.Replace(".", ",");
            //            string name = column1;
            //            double latDouble = Convert.ToDouble(lat);
            //            double lngDouble = Convert.ToDouble(lng);                        
            //            Console.WriteLine(lat);
            //            Console.WriteLine(lat.Length);
            //            Console.WriteLine(lng);
            //            Console.WriteLine(lng.Length);
            //            Console.WriteLine("-------------------");
            //            uof.CityRepository.Add(new CityEntity(column1, lngDouble, latDouble));
            //        }

            //    }
            //}

            //uof.Complete();
            //foreach (CityEntity city in uof.CityRepository.GetAll()) 
            //{
            //    uof.IssuePointRepository.Add(new IssuePointEntity(city.ID, "Poshtovy avenue 16"));
            //    uof.IssuePointRepository.Add(new IssuePointEntity(city.ID, "Neuton street 44"));
            //    uof.IssuePointRepository.Add(new IssuePointEntity(city.ID, "Baker Street 12"));
            //    uof.IssuePointRepository.Add(new IssuePointEntity(city.ID, "Bankova street 42"));
            //}
            //uof.Complete();

            //uof.SupplierRepository.Add(new SupplierEntity("Phizer"));
            //uof.SupplierRepository.Add(new SupplierEntity("Farmak"));
            //uof.SupplierRepository.Add(new SupplierEntity("Moderna"));
            //uof.SupplierRepository.Add(new SupplierEntity("Avizor"));
            //uof.SupplierRepository.Add(new SupplierEntity("Skynet"));
            //uof.SupplierRepository.Add(new SupplierEntity("Johnson & Johnson"));
            //uof.SupplierRepository.Add(new SupplierEntity("Roche"));
            //uof.SupplierRepository.Add(new SupplierEntity("Merck & Co."));
            //uof.SupplierRepository.Add(new SupplierEntity("Bristol Myers Squibb"));

            //uof.Complete();

            //List<int> factoryCount =  new List<int>() { 2, 4, 6, 7, 8, 9 };


            //foreach (CityEntity city in uof.CityRepository.GetAll()) 
            //{
            //    List<string> names = new List<string>() { "Kyiv", "Kharkiv", "Donetsk", "Dnipro", "Odesa", "Sevastopol", "Lviv", "Mykolaiv", "Ternopil", "Poltava", "Rivne", "Konotop", "Melitopil", "Cherkasy", "Kaniv", "Balta", "Zhovti Vody", "Sumy", "Kalanchak"};
            //    if (names.Contains(city.CityName)) 
            //    {
            //        Random randCount = new Random();

            //        for (int i =0; i <= factoryCount[randCount.Next(factoryCount.Count)]; i++) 
            //        {
            //            Random rand = new Random();

            //            uof.FactoryRepository.Add(new FactoryEntity(city.ID, addresses[rand.Next(addresses.Count)], uof.SupplierRepository.GetAll().ToList()[rand.Next(uof.SupplierRepository.GetAll().ToList().Count)].ID));

            //        }


            //    }
            //}

            //uof.Complete();

            //using (TextFieldParser parser = new TextFieldParser("C:/Users/Robert/source/repos/RobertDubson_Medical_Order_Processing_System/RobertDubson_Medical_Order_Processing_System/CBP-Suppliers-Products-Carried.csv"))
            //{
            //    parser.TextFieldType = FieldType.Delimited;
            //    parser.SetDelimiters(",");

            //    // Read the headers to determine the index of each column
            //    string[] headers = parser.ReadFields();
            //    int column1Index = Array.IndexOf(headers, "product_name");
            //    int column2Index = Array.IndexOf(headers, "manufacturer");

            //    List<string> productsInserted = new List<string>();
            //    List<string> manufacturers = new List<string>();

            //    // Loop through the remaining lines in the file and extract the specified columns
            //    while (!parser.EndOfData)
            //    {
            //        string[] fields = parser.ReadFields();

            //        string product = fields[column1Index];
            //        string manufacturer = fields[column2Index];
            //        if (!productsInserted.Contains(product) & !manufacturers.Contains(manufacturer))
            //        {
            //            uof.MedicalProductRepository.Add(new MedicalProductEntity(product, "", ""));
            //            uof.SupplierRepository.Add(new SupplierEntity(manufacturer));
            //            manufacturers.Add(manufacturer);
            //            productsInserted.Add(product);
            //        }

            //        // Do something with the extracted columns, such as adding them to a list or database

            //    }
            //}

            //uof.Complete();

        }
    }
}
