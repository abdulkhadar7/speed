using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpeedBillingApplication.Models;
using System.Data;
namespace SpeedBillingApplication.DBLayer
{
    public class ProductDBOperations
    {
        SpeedDatabaseEntities entity;
        Message msg;
        /// <summary>
        //Return All Product List
        /// </summary>
        /// <returns></returns>
        internal List<ProductModel> GetAllProducts()
        {
            using (entity = new SpeedDatabaseEntities())
            {
                var result = (from product in entity.Products
                              orderby product.ProductName
                              select new ProductModel
                              {
                                  cgst = product.CGST,
                                  hsn = product.HSN,
                                  igst = product.IGST,
                                  productId = product.ProductID,
                                  productName = product.ProductName,
                                  sgst = product.SGST
                              }).ToList();
                int i = 0;
                foreach (var item in result)
                {
                    item.slNo = ++i;
                }
                return result;
            }
        }

        internal Message AddProductDB(ProductModel data)
        {
            msg = new Message();
            try
            {
                using (entity = new SpeedDatabaseEntities())
                {
                    Product pr = new Product();
                    pr.CGST = data.cgst;
                    pr.HSN = data.hsn;
                    pr.IGST = data.igst;
                    pr.ProductName = data.productName;
                    pr.SGST = data.sgst;
                    entity.Products.Add(pr);
                    entity.SaveChanges();
                    msg.success = true;
                    return msg;
                }
            }
            catch(DataException ex)
            {
                msg.message = ex.Message;
                msg.success = false;
                return msg;
            }
        }

        internal Product GetProductById(int productId)
        {
            using (entity = new SpeedDatabaseEntities())
            {
                Product data = entity.Products.Where(s => s.ProductID == productId).FirstOrDefault();
                return data;
            }
        }
        internal Message UpdateProduct(Product data)
        {
            msg = new Message();
            try
            {
                using (entity = new SpeedDatabaseEntities())
                {
                    Product obj = entity.Products.Where(s => s.ProductID == data.ProductID).FirstOrDefault();
                    obj.CGST = data.CGST;
                    obj.HSN = data.HSN;
                    obj.IGST = data.IGST;
                    obj.ProductName = data.ProductName;
                    obj.SGST = data.SGST;
                    entity.SaveChanges();
                    msg.success = true;
                    return msg;
                }                
            }
            catch(DataException ex)
            {
                msg.message = ex.Message;
                msg.success = false;
                return msg;
            }
        }

        internal Message deleteProductById(int productId)
        {
            msg = new Message();
            using (entity = new SpeedDatabaseEntities())
            {
                if(entity.PurchaseDetails.Any(s=>s.ProductID==productId))
                {
                    msg.message = "Product Exists in Purchase Entry. Please Delete Purchase";
                    msg.success = false;
                    return msg;
                }
                else
                {
                    Product obj = entity.Products.Where(s => s.ProductID == productId).FirstOrDefault();
                    entity.Products.Remove(obj);
                    entity.SaveChanges();
                    msg.success = true;
                    return msg;
                }
            }
        }
    }
}