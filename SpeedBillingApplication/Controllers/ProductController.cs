using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpeedBillingApplication.DBLayer;
using SpeedBillingApplication.Models;

namespace SpeedBillingApplication.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductDBOperations dboper;
        Message msg;
        public ActionResult Index()
        {
            dboper = new ProductDBOperations();
            List<ProductModel> data = dboper.GetAllProducts();
            return View(data);
        }
        /// <summary>
        /// Add product partial view generation
        /// </summary>
        /// <returns></returns>
        public ActionResult AddProduct()
        {
            return PartialView("_AddProduct");
        }
        /// <summary>
        ///  Adding new product to DB
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
       [HttpPost]
       public ActionResult AddProduct(ProductModel data)
        {
            dboper = new ProductDBOperations();
            msg = dboper.AddProductDB(data);            
            if(msg.success)
            {
                TempData["success"] = "Product Added Successfully";
            }
            else
            {
                TempData["fail"] = "Error! Please try later."+msg.message;
            }
            return RedirectToAction("Index", "Product");
        }
        /// <summary>
        ///  Getting product details for editing 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ActionResult EditProduct(int productId)
        {
            dboper = new ProductDBOperations();
            Product obj = dboper.GetProductById(productId);
            return PartialView("_EditProduct",obj);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product data)
        {
            dboper = new ProductDBOperations();
            msg = dboper.UpdateProduct(data);
            if (msg.success)
            {
                TempData["success"] = "Product Updated Successfully";
            }
            else
            {
                TempData["fail"] = "Error! Please try later."+msg.message;
            }
            return RedirectToAction("Index", "Product");
        }

        public ActionResult DeleteProduct(int productId)
        {
            dboper = new ProductDBOperations();
            msg = dboper.deleteProductById(productId);
            if (msg.success)
            {
                TempData["success"] = "Product Deleted Successfully";
            }
            else
            {
                TempData["fail"] = "Error! Please try later." + msg.message;
            }
            return RedirectToAction("Index", "Product");
        }
    }
}