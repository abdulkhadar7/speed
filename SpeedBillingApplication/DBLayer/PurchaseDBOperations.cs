using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpeedBillingApplication.Models;
using System.Data;

namespace SpeedBillingApplication.DBLayer
{
    public class PurchaseDBOperations
    {
        SpeedDatabaseEntities entity;
        Message msg;
        internal List<PurchaseMainModel> GetAllPurchase()
        {
            using (entity = new SpeedDatabaseEntities())
            {
                var result = (from pm in entity.PurchaseMains
                              join sm in entity.SupplierMains on pm.SupplierID equals sm.SupplierID
                              select new PurchaseMainModel
                              {
                                  pucrhaseDate = pm.PurchaseDate,
                                  supplierId = (int)pm.SupplierID,
                                  supplierName = sm.SupplierName,
                                  totalAmountPaid = pm.TotalAmountPaid,
                                  totalPurchaseCost = pm.TotalPurchaseAmount,
                                  totalPurchaseCredit = pm.TotalPurchaseCredit,
                                  purchaseId = pm.PurchaseID
                              }).ToList();

                int i = 1;
                foreach(var item in result)
                {
                    item.slNo = i++;
                    item.date = item.pucrhaseDate.ToString("dd-MMM-yy");
                }
                return result;
            }
        }
    }
}