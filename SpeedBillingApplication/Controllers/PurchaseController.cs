using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpeedBillingApplication.DBLayer;
using SpeedBillingApplication.Models;
namespace SpeedBillingApplication.Controllers
{
    public class PurchaseController : Controller
    {

        PurchaseDBOperations dboper;

        // GET: Purchase
        public ActionResult Index()
        {
            dboper = new PurchaseDBOperations();
         List<PurchaseMainModel> data = dboper.GetAllPurchase();
            return View(data);
        }

        public ActionResult AddPurchase()
        {

        }
    }
}