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
            return new ReceiptEntity(example.ID, example.ClientID, example.AuthorID, example.AppointmentReview, example.OrderStatusID, example.ShipToTheIssuePoint, example.DestinationCityID);
        }

        public Receipt FromEntityToDomain(ReceiptEntity example)
        {
            return new Receipt(example.ID, example.ClientID, example.AuthorID, example.AppointmentReview, example.OrderStatusID, example.ShipToTheIssuePoint, example.DestinationCityID);
        }

        public ReceiptEntity NewExample(Receipt example)
        {
            return new ReceiptEntity(example.ClientID, example.AuthorID, example.AppointmentReview, example.OrderStatusID, example.ShipToTheIssuePoint, example.DestinationCityID);
        }
    }
}
