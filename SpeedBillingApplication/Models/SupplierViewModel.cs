using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedBillingApplication.Models
{
    public class SupplierViewModel
    {
        public SupplierModel supplierModel { get; set; }
        public List<SupplierDetailModel> supplierDetailList { get; set; }
    }
    public class SupplierModel
    {
        public int slNo { get; set; }
        public int supplierId { get; set; }
        public string supplierName { get; set; }
        public int TotalPurchaseCost { get; set; }
        public int TotalPurchaseCredit { get; set; }
    }
    public class SupplierDetailModel
    {
        public int supplierSeq { get; set; }
        public int supplierId { get; set; }
        public int purchaseId { get; set; }
        public int purchaseAmount { get; set; }
        public int amountPaid { get; set; }
        public int supplierCredit { get; set; }
    }
}