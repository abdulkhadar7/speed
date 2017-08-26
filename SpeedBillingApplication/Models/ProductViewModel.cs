using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedBillingApplication.Models
{
    public class ProductViewModel
    {
    }
    public class ProductModel
    {
        public int slNo { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public int hsn { get; set; }
        public decimal sgst { get; set; }
        public decimal cgst { get; set; }
        public decimal igst { get; set; }
    }
}