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
    
    public partial class SaleDetail
    {
        public int SaleID { get; set; }
        public int SaleSeq { get; set; }
        public int ProductID { get; set; }
        public Nullable<decimal> SaleRate { get; set; }
        public Nullable<decimal> SaleQuantity { get; set; }
        public Nullable<decimal> SaleAmount { get; set; }
    }
}