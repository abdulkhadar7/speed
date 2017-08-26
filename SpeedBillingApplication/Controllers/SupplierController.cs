using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpeedBillingApplication.DBLayer;
using SpeedBillingApplication.Models;
namespace SpeedBillingApplication.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        Message msg;
        SupplierDBOperations dboper;
        public ActionResult Index()
        {
            dboper = new SupplierDBOperations();
            List<SupplierModel> data = dboper.GetAllSuppliers();
            return View(data);
        }

        public ActionResult AddSupplier()
        {
            return PartialView("_AddSupplier");
        }

        [HttpPost]
        public ActionResult AddSupplier(SupplierMain data)
        {
            dboper = new SupplierDBOperations();
            msg = dboper.AddSupplierDB(data);
            if (msg.success)
            {
                TempData["success"] = "Supplier Added Successfully";
            }
            else
            {
                TempData["fail"] = "Error! Please try later." + msg.message;
            }
            return RedirectToAction("Index", "Supplier");
        }

        public ActionResult EditSupplier(int supplierId)
        {
            dboper = new SupplierDBOperations();
            SupplierMain obj = dboper.GetSupplierByID(supplierId);
            return PartialView("_EditSupplier", obj);
        }
        [HttpPost]
        public ActionResult EditSupplier(SupplierMain data)
        {
            dboper = new SupplierDBOperations();
            msg = dboper.UpdateSupplier(data);
            if (msg.success)
            {
                TempData["success"] = "Supplier Details Updated Successfully";
            }
            else
            {
                TempData["fail"] = "Error! Please try later." + msg.message;
            }
            return RedirectToAction("Index", "Supplier");
        }

        public ActionResult DeleteSupplier(int supplierId)
        {
            dboper = new SupplierDBOperations();
            msg = dboper.DeleteSupplierByID(supplierId);
            if (msg.success)
            {
                TempData["success"] = "Supplier Deleted Successfully";
            }
            else
            {
                TempData["fail"] = "Error! Please try later." + msg.message;
            }
            return RedirectToAction("Index", "Supplier");
        }
    }
}