using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class ReceiptAndProductEntity : BaseEntity
    {
        public int ReceiptID { get; set; }

        public int ProductID { get; set; }

        public int CityID { get; set; }

        public int FactoryID { get; set; }

        public int DeliveryCompanyID { get; set; }

        public ReceiptAndProductEntity(int id, int receiptId, int productId, int cityId, int factoryId, int companyId)
        {
            ID = id;

            ReceiptID = receiptId;

            ProductID = productId;

            CityID = cityId;

            FactoryID = factoryId;

            DeliveryCompanyID = companyId;
        }

        public ReceiptAndProductEntity(int receiptId, int productId, int cityId, int factoryId, int companyId)
        {

            ReceiptID = receiptId;

            ProductID = productId;

            CityID = cityId;

            FactoryID = factoryId;

            DeliveryCompanyID = companyId;
        }

        public ReceiptAndProductEntity()
        {

        }
    }
}
