//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpeedBillingApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseMain
    {
        public int PurchaseID { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public int TotalPurchaseAmount { get; set; }
        public int TotalAmountPaid { get; set; }
        public int TotalPurchaseCredit { get; set; }
        public Nullable<int> SupplierID { get; set; }
    }
}
