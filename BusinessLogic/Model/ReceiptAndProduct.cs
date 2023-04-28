using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ReceiptAndProduct : BaseModel
    {

        public int ReceiptID { get; set; }

        public int ProductID { get; set; }

        public ReceiptAndProduct(int id, int receiptId, int productId)
        {
            ID = id;

            ReceiptID = receiptId;

            ProductID = productId;
        }

        public ReceiptAndProduct(int receiptId, int productId)
        {
            ReceiptID = receiptId;

            ProductID = productId;
        }
    }
}
