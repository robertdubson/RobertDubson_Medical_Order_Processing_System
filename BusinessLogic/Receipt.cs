using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Receipt
    {
        public Client PrecriptedTo { get; set; }

        public Doctor Author { get; set; }

        public string AppointmentReview { get; set; }

        public List<MedicalProduct> PrescriptedProducts { get; set; }

        public Status OrderStatus { get; set; }

    }
}
