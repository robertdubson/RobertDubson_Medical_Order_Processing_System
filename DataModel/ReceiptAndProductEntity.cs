using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class ReceiptAndProductEntity : BaseEntity
    {
        public int ReceiptID { get; set; }

        public int ProductID { get; set; }

        public ReceiptAndProductEntity(int id, int receiptId, int productId)
        {
            ID = id;

            ReceiptID = receiptId;

            ProductID = productId;
        }

        public ReceiptAndProductEntity(int receiptId, int productId)
        {

            ReceiptID = receiptId;

            ProductID = productId;
        }

        public ReceiptAndProductEntity()
        {

        }
    }
}
