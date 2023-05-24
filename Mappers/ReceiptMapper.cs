using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using DataModel;
namespace Mappers
{
    public class ReceiptMapper : IMapper<ReceiptEntity, Receipt>
    {
        public ReceiptEntity FromDomainToEntity(Receipt example)
        {
            ReceiptEntity receiptEntity = new ReceiptEntity(example.ID, example.ClientID, example.AuthorID, example.AppointmentReview, example.OrderStatusID, example.ShipToTheIssuePoint, example.DestinationCityID, example.CreationDate, example.Cost);

            receiptEntity.Cost = example.Cost;

            receiptEntity.CreationDate = example.CreationDate;

            return receiptEntity;
        }

        public Receipt FromEntityToDomain(ReceiptEntity example)
        {
            Receipt receipt = new Receipt(example.ID, example.ClientID, example.AuthorID, example.AppointmentReview, example.OrderStatusID, example.ShipToTheIssuePoint, example.DestinationCityID, example.CreationDate, example.Cost);

            receipt.Cost = example.Cost;

            receipt.CreationDate = example.CreationDate;

            return receipt;
        }

        public ReceiptEntity NewExample(Receipt example)
        {
            ReceiptEntity receiptEntity = new ReceiptEntity(example.ClientID, example.AuthorID, example.AppointmentReview, example.OrderStatusID, example.ShipToTheIssuePoint, example.DestinationCityID, example.CreationDate, example.Cost);

            receiptEntity.Cost = example.Cost;

            receiptEntity.CreationDate = example.CreationDate;

            return receiptEntity;
        }
    }
}
