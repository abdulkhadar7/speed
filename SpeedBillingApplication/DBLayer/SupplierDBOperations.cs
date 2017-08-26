using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SpeedBillingApplication.Models;
namespace SpeedBillingApplication.DBLayer
{
    public class SupplierDBOperations
    {
        SpeedDatabaseEntities entity;
        Message msg;
        internal List<SupplierModel> GetAllSuppliers()
        {
            using (entity = new SpeedDatabaseEntities())
            {
                var result = (from supp in entity.SupplierMains
                              orderby supp.SupplierName
                              select new SupplierModel
                              {
                                  supplierId = supp.SupplierID,
                                  supplierName = supp.SupplierName,
                                  TotalPurchaseCost = (Int32)supp.TotalPurchaseCost,
                                  TotalPurchaseCredit = supp.TotalSupplierCredit
                              }).ToList();

                int i = 1;
                foreach(var item in result)
                {
                    item.slNo = i++;
                }
                return result;
            }
        }

        internal Message AddSupplierDB(SupplierMain data)
        {
            msg = new Message();
            try
            {
                using (entity = new SpeedDatabaseEntities())
                {
                    SupplierMain sm = new SupplierMain();
                    sm.SupplierAddress = data.SupplierAddress;
                    sm.SupplierName = data.SupplierName;
                    sm.TotalPurchaseCost = 0;
                    sm.TotalSupplierCredit = 0;
                    entity.SupplierMains.Add(sm);
                    entity.SaveChanges();

                    msg.success = true;
                    return msg;
                }
            }
            catch(DataException ex)
            {
                msg.success = false;
                msg.message = ex.Message;
                return msg;
            }
        }
        
        internal SupplierMain GetSupplierByID(int supplierId)
        {
            using (entity = new SpeedDatabaseEntities())
            {
                SupplierMain data = entity.SupplierMains.Where(s => s.SupplierID == supplierId).FirstOrDefault();
                return data;
            }
        }


        internal Message UpdateSupplier(SupplierMain data)
        {
            msg = new Message();
            using (entity = new SpeedDatabaseEntities())
            {
                try
                {
                    SupplierMain sm = entity.SupplierMains.Where(s => s.SupplierID == data.SupplierID).FirstOrDefault();
                    sm.SupplierAddress = data.SupplierAddress;
                    sm.SupplierName = data.SupplierName;
                    entity.SaveChanges();

                    msg.success = true;
                    return msg;
                }
                catch (DataException ex)
                {
                    msg.success = false;
                    msg.message = ex.Message;
                    return msg;
                }
            }
        }
        internal Message DeleteSupplierByID(int supplierId)
        {
            msg = new Message();
            try
            {
                using (entity = new SpeedDatabaseEntities())
                {
                    if(entity.PurchaseMains.Any(s=>s.SupplierID==supplierId))
                    {
                        int purchaseid = entity.PurchaseMains.Where(s => s.SupplierID == supplierId).FirstOrDefault().PurchaseID;
                        msg.message = "Purchase has entries with selected Supplier. Please delete purchase with ID: " + purchaseid;
                        msg.success = false;
                        return msg;
                    }
                    else
                    {
                        entity.SupplierDetails.RemoveRange(entity.SupplierDetails.Where(s => s.SupplierID == supplierId));
                        entity.SupplierMains.Remove(entity.SupplierMains.Where(s => s.SupplierID == supplierId).FirstOrDefault());
                        entity.SaveChanges();
                        msg.success = true;
                        return msg;
                    }
                }
            }
            catch(DataException ex)
            {
                msg.message = ex.Message;
                msg.success = true;
                return msg;

            }
        }
    }
}