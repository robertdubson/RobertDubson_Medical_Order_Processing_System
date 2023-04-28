using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Receipt : BaseModel
    {
        
        public int ClientID { get; set; }

        public int AuthorID { get; set; }

        public string AppointmentReview { get; set; }       

        public int OrderStatusID { get; set; }

        public bool ShipToTheIssuePoint { get; set; }

        public int DestinationCityID { get; set; }

        public Receipt(int id, int clientid, int authorId, string review, int statusId, bool shipToPoint, int destinationId)
        {
            ID = id;

            ClientID = clientid;

            AuthorID = authorId;

            AppointmentReview = review;

            OrderStatusID = statusId;

            ShipToTheIssuePoint = shipToPoint;

            DestinationCityID = destinationId;


        }

        public Receipt(int clientid, int authorId, string review, int statusId, bool shipToPoint, int destinationId)
        {
            ClientID = clientid;

            AuthorID = authorId;

            AppointmentReview = review;

            OrderStatusID = statusId;

            ShipToTheIssuePoint = shipToPoint;

            DestinationCityID = destinationId;
        }

    }
}
