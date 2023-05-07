using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Services.Abstract;
using BusinessLogic;
using DataLayer.UnitOfWork;
using Mappers;
namespace Services
{
    public class ReceiptService : IReceiptService
    {
        IUnitOfWork _unitOfWork;

        ReceiptMapper _receiptMapper;

        public ReceiptService(IUnitOfWork uof)
        {
            _unitOfWork = uof;

            _receiptMapper = new ReceiptMapper();
        }

        //public Receipt GenerateOptimizedrReceipt() 
        //{
        //    return new Receipt();
        //}

        public void AddReceipt(Receipt receipt) 
        {
            _unitOfWork.ReceiptRepository.Add(_receiptMapper.NewExample(receipt));
        }

        public void DeleteReceipt(int Id)
        {
            _unitOfWork.ReceiptRepository.Delete(Id);
        }

        public List<Receipt> GetAllReceipts()
        {
            return _unitOfWork.ReceiptRepository.GetAll().ToList().Select(rec => _receiptMapper.FromEntityToDomain(rec)).ToList();
        }

        public List<Receipt> GetAllReceiptsByDoctorId(int doctorId)
        {
            return _unitOfWork.ReceiptRepository.GetReceiptsByDoctorId(doctorId).ToList().Select(rec => _receiptMapper.FromEntityToDomain(rec)).ToList();
        }

        public Receipt GetReceiptById(int id)
        {
            return _receiptMapper.FromEntityToDomain(_unitOfWork.ReceiptRepository.GetByID(id));
        }

        public void UpdateReceipt(Receipt receipt)
        {
            _unitOfWork.ReceiptRepository.Update(_receiptMapper.FromDomainToEntity(receipt));
        }
    }
}
