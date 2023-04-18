using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Factory
    {
        public City Location { get; set; }

        public List<MedicalProduct> AvailableProducts { get; set; }
    }
}
