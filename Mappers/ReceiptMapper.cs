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
            ReceiptEntity receiptEntity = new ReceiptEntity(example.ID, example.ClientID, example.AuthorID, example.AppointmentReview, example.OrderStatusID, example.ShipToTheIssuePoint, example.DestinationCityID, example.CreationDate);

            receiptEntity.Cost = example.Cost;


            return receiptEntity;
        }

        public Receipt FromEntityToDomain(ReceiptEntity example)
        {
            Receipt receipt = new Receipt(example.ID, example.ClientID, example.AuthorID, example.AppointmentReview, example.OrderStatusID, example.ShipToTheIssuePoint, example.DestinationCityID, example.CreationDate);

            receipt.Cost = example.Cost;

            return receipt;
        }

        public ReceiptEntity NewExample(Receipt example)
        {
            ReceiptEntity receiptEntity = new ReceiptEntity(example.ClientID, example.AuthorID, example.AppointmentReview, example.OrderStatusID, example.ShipToTheIssuePoint, example.DestinationCityID, example.CreationDate);

            receiptEntity.Cost = example.Cost;

            return receiptEntity;
        }
    }
}
