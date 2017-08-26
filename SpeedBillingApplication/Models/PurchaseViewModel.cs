using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedBillingApplication.Models
{
    public class PurchaseViewModel
    {
        public PurchaseMainModel modelObj { get; set; }
        public List<PurchaseDetailModel> ListPurDetail { get; set; }
    }

    public class PurchaseMainModel
    {
        public int slNo { get; set; }
        public int purchaseId { get; set; }
        public int supplierId { get; set; }

        public string supplierName { get; set; }
        public DateTime pucrhaseDate { get; set; }
        public string date { get; set; }
        public int totalPurchaseCost { get; set; }
        public int totalAmountPaid { get; set; }
        public int totalPurchaseCredit { get; set; }
    }
    public class PurchaseDetailModel
    {
        public int purchaseId { get; set; }
        public int purchaseSeq { get; set; }
        public int productId { get; set; }
        public decimal purchaseRate { get; set;  }  
        public decimal purchaseQuantity { get; set; }
        public decimal purchaseAmount { get; set; }
    }
}