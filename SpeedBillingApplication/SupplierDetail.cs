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
    
    public partial class SupplierDetail
    {
        public int SupplierID { get; set; }
        public int SupplierSeq { get; set; }
        public int PurchaseID { get; set; }
        public int PurchaseAmount { get; set; }
        public Nullable<int> AmountPaid { get; set; }
        public Nullable<int> SupplierCredit { get; set; }
    }
}