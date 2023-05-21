using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
namespace MedicalDeliveryService.Models
{
    public class ReceiptViewModel
    {
        public List<MedicalProduct> PrescriptedProducts { get; set; }

        public Receipt Receipt { get; set; }

        public Doctor Doctor { get; set; }

        public double Cost { get; set; }

        public string DoctorName { get; set; }

        public string AppointmentReview { get; set; }

        public ReceiptViewModel(List<MedicalProduct> products, Receipt receipt, Doctor doctor)
        {
            PrescriptedProducts = products;

            Receipt = receipt;

            Doctor = doctor;

            Cost = receipt.Cost;

            DoctorName = Doctor.Name;

            AppointmentReview = receipt.AppointmentReview;

        }

    }
}
