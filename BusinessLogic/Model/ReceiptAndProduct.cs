using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ReceiptAndProduct : BaseModel
    {

        public int ReceiptID { get; set; }

        public int ProductID { get; set; }

        public int CityID { get; set; }

        public int FactoryID { get; set; }

        public int DeliveryCompanyID { get; set; }

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

        public ReceiptAndProduct(int Id, int receiptID, int productID, int cityID, int factoryID, int deliveryCompanyID)
        {
            ID = Id;
            ReceiptID = receiptID;
            ProductID = productID;
            CityID = cityID;
            FactoryID = factoryID;
            DeliveryCompanyID = deliveryCompanyID;
        }

        public ReceiptAndProduct(int receiptID, int productID, int cityID, int factoryID, int deliveryCompanyID)
        {
            ReceiptID = receiptID;
            ProductID = productID;
            CityID = cityID;
            FactoryID = factoryID;
            DeliveryCompanyID = deliveryCompanyID;
        }
    }
}
