using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Receipt
    {
        
        public int ID { get; private set; }
        
        public int ClientID { get; set; }

        public int AuthorID { get; set; }

        public string AppointmentReview { get; set; }       

        public int OrderStatusID { get; set; }

        public bool ShipToTheIssuePoint { get; set; }

        public int DestinationCityID { get; set; }

    }
}
