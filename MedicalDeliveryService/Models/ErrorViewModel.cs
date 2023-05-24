using System;

namespace MedicalDeliveryService.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string ErrorCause { get; set; }
        public ErrorViewModel(string cause)
        {
            ErrorCause = cause;
        }
        public ErrorViewModel()
        {
                
        }


    }
}
