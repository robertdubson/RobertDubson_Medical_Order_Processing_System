﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
namespace MedicalDeliveryService.Models
{
    public class ReceiptViewModel
    {
        public List<SupplyChainViewModel> Chains { get; set; }

        public List<MedicalProduct> PrescriptedProducts { get; set; }

        public Receipt Receipt { get; set; }

        public Doctor Doctor { get; set; }

        public double Cost { get; set; }

        public string DoctorName { get; set; }

        public string ClientName { get; set; }

        public string AppointmentReview { get; set; }

        public string StatusStr { get; set; }

        public Client Client { get; set; }

        public BusinessLogic.AlgorithmLogger AlgorithmLogger { get; set; }

        public ReceiptViewModel(List<MedicalProduct> products, Receipt receipt, Doctor doctor)
        {
            PrescriptedProducts = products;

            Receipt = receipt;

            Doctor = doctor;

            Cost = receipt.Cost;

            DoctorName = Doctor.Name;

            AppointmentReview = receipt.AppointmentReview;

            if (receipt.OrderStatusID == 1)
            {
                StatusStr = "Shipped";

            }
            else if (receipt.OrderStatusID == 2) 
            {
                StatusStr = "In Process";
            }

        }

        public ReceiptViewModel(List<MedicalProduct> products, Receipt receipt, Doctor doctor, Client client)
        {
            PrescriptedProducts = products;

            Receipt = receipt;

            Doctor = doctor;

            Cost = receipt.Cost;

            DoctorName = Doctor.Name;

            AppointmentReview = receipt.AppointmentReview;

            ClientName = client.Name;

            if (receipt.OrderStatusID == 1)
            {
                StatusStr = "Shipped";

            }
            else if (receipt.OrderStatusID == 2)
            {
                StatusStr = "In Process";
            }

        }

        public ReceiptViewModel(List<MedicalProduct> products, Receipt receipt, Doctor doctor, Client client, BusinessLogic.AlgorithmLogger logger)
        {
            PrescriptedProducts = products;

            Receipt = receipt;

            Doctor = doctor;

            Cost = receipt.Cost;

            DoctorName = Doctor.Name;

            AppointmentReview = receipt.AppointmentReview;

            ClientName = client.Name;

            if (receipt.OrderStatusID == 1)
            {
                StatusStr = "Shipped";

            }
            else if (receipt.OrderStatusID == 2)
            {
                StatusStr = "In Process";
            }

            AlgorithmLogger = logger;

        }

        public ReceiptViewModel(List<MedicalProduct> products, Receipt receipt, Doctor doctor, BusinessLogic.AlgorithmLogger logger)
        {
            PrescriptedProducts = products;

            Receipt = receipt;

            Doctor = doctor;

            Cost = receipt.Cost;

            DoctorName = Doctor.Name;

            AppointmentReview = receipt.AppointmentReview;

            if (receipt.OrderStatusID == 1)
            {
                StatusStr = "Shipped";

            }
            else if (receipt.OrderStatusID == 2)
            {
                StatusStr = "In Process";
            }

            AlgorithmLogger = logger;

        }

    }
}
