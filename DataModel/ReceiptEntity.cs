using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class ReceiptEntity : BaseEntity
    {
        public int ClientID { get; set; }

        public int AuthorID { get; set; }

        public string AppointmentReview { get; set; }

        public int OrderStatusID { get; set; }

        public bool ShipToTheIssuePoint { get; set; }

        public int DestinationCityID { get; set; }

        public DateTime CreationDate { get; set; }

        public double Cost { get; set; }

        public ReceiptEntity(int id, int clientid, int authorId, string review, int statusId, bool shipToPoint, int destinationId, DateTime creationDate)
        {
            ID = id;

            ClientID = clientid;

            AuthorID = authorId;

            AppointmentReview = review;

            OrderStatusID = statusId;

            ShipToTheIssuePoint = shipToPoint;

            DestinationCityID = destinationId;

            CreationDate = creationDate;

            Cost = 0;


        }

        public ReceiptEntity(int clientid, int authorId, string review, int statusId, bool shipToPoint, int destinationId, DateTime creationDate)
        {

            ClientID = clientid;

            AuthorID = authorId;

            AppointmentReview = review;

            OrderStatusID = statusId;

            ShipToTheIssuePoint = shipToPoint;

            DestinationCityID = destinationId;

            CreationDate = CreationDate;

            Cost = 0;


        }

        public ReceiptEntity()
        {

        }
    }
}
