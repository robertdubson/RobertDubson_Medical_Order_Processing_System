using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
namespace MedicalDeliveryService.Models
{
    public class ReceiptPreparationViewModel
    {

        public int ID { get; set; }
        
        public int ClientID { get; set; }

        public int AuthorID { get; set; }

        public string AppointmentReview { get; set; }

        public int OrderStatusID { get; set; }

        public bool ShipToTheIssuePoint { get; set; }

        public int DestinationCityID { get; set; }

        public List<SelectListItem> PossibleDoctors { get; set; }

        public List<SelectListItem> PossibleClients { get; set; }

        public List<SelectListItem> PossibleProducts { get; set; }

        public List<MedicalProduct> PossibleProductModels { get; set; }

        public List<MedicalProduct> PrescriptedProducts { get; set; }

        public List<Client> PossibleClientModels { get; set; }

        public List<Doctor> PossibleDoctorModels { get; set; }

        public Status OrderStatus { get; set; }

        public Doctor Doctor { get; set; }

        public Client Client { get; set; }

        public ReceiptPreparationViewModel(List<MedicalProduct> products, List<Client> clients, List<Doctor> doctors) 
        {
            PossibleClients = new List<SelectListItem>();

            PossibleDoctors = new List<SelectListItem>();

            PossibleProducts = new List<SelectListItem>();

            PrescriptedProducts = new List<MedicalProduct>();

            PossibleClientModels = clients;

            PossibleDoctorModels = doctors;

            PossibleProductModels = products;

            PossibleProductModels.ForEach(prod => PossibleProducts.Add(new SelectListItem(prod.ProductName, prod.ID.ToString())));

            PossibleClientModels.ForEach(cl => PossibleClients.Add(new SelectListItem(cl.UserName, cl.ID.ToString())));

            PossibleDoctorModels.ForEach(dc => PossibleDoctors.Add(new SelectListItem(dc.Name, dc.ID.ToString())));
        }

        public ReceiptPreparationViewModel(List<MedicalProduct> products, Client client, Doctor doctor)
        {
            PossibleClients = new List<SelectListItem>();

            PossibleDoctors = new List<SelectListItem>();

            PossibleProducts = new List<SelectListItem>();

            PrescriptedProducts = new List<MedicalProduct>();

            PossibleProductModels = products;

            Doctor = doctor;

            Client = client;

            PossibleProductModels.ForEach(prod => PossibleProducts.Add(new SelectListItem(prod.ProductName, prod.ID.ToString())));

        }
    }
}
