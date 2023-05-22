using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
namespace Services.Abstract
{
    public interface IReceiptService
    {
        public List<Receipt> GetAllReceipts();

        public Receipt GetReceiptById(int id);

        public List<ReceiptAndProduct> GetReceiptDetails(int id);

        public List<Receipt> GetAllReceiptsByDoctorId(int doctorId);

        public List<Receipt> GetAllReceiptsByClientId(int clientId);

        public void UpdateReceipt(Receipt receipt);

        public void DeleteReceipt(int Id);

        public void AddReceipt(Receipt receipt);

        public void AddChainOfSolutions(City destination, List<MedicalProduct> purchasedProducts);

        public void AddSolution(ReceiptAndProduct solution);

        public List<ReceiptAndProduct> GenerateOptimizedReceipt(City destination, List<MedicalProduct> purchasedProducts);

        public List<MedicalProduct> GetPrescriptedProducts(int receiptId);
    }
}
