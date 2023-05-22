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

        public DateTime CreationDate { get; set; }

        public double Cost { get; set; }

        public Receipt(int id, int clientid, int authorId, string review, int statusId, bool shipToPoint, int destinationId, DateTime creationDate, double cost)
        {
            ID = id;

            ClientID = clientid;

            AuthorID = authorId;

            AppointmentReview = review;

            OrderStatusID = statusId;

            ShipToTheIssuePoint = shipToPoint;

            DestinationCityID = destinationId;

            CreationDate = creationDate;

            Cost = cost;

            //Cost = 0;


        }

        public Receipt(int clientid, int authorId, string review, int statusId, bool shipToPoint, int destinationId, double cost)
        {
            ClientID = clientid;

            AuthorID = authorId;

            AppointmentReview = review;

            OrderStatusID = statusId;

            ShipToTheIssuePoint = shipToPoint;

            DestinationCityID = destinationId;

            Cost = cost;
            //Cost = 0;
        }

    }
}
