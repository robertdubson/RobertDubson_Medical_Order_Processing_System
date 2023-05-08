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

        public List<Receipt> GetAllReceiptsByDoctorId(int doctorId);

        public void UpdateReceipt(Receipt receipt);

        public void DeleteReceipt(int Id);

        public void AddReceipt(Receipt receipt);

        public void AddChainOfSolutions(City destination, List<MedicalProduct> purchasedProducts);

        public List<ReceiptAndProduct> GenerateOptimizedReceipt(City destination, List<MedicalProduct> purchasedProducts);
    }
}
