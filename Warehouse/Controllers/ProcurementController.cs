using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class ProcurementController : Controller
    {
        public ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Procurement
        public ActionResult Index()
        {

            var username = User.Identity.Name;
            var user = (from u in _db.UserModels where u.UserName == username select u).FirstOrDefault();
            ViewBag.user = user.Name;
            
            ViewData["computers"] = _db.ComputerListModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();
         
            return View();

        }


        public ActionResult Invoice(ProcurementModels procurement)
        {
           
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Invoice(FormCollection form)
        {
            int laptopID = Convert.ToInt32(form["computers"]);

            var laptopName = (from l in _db.ComputerListModels where l.ID == laptopID select l.Name).FirstOrDefault();

            var quantity = Convert.ToInt32(form["quantity"]);

            int? id = (from p in _db.ProcurementModels orderby p.ID descending select p.ID).FirstOrDefault();

            if (id == null)
            {
                id = 0;
            }


            string invoiceNo = "0000" + id;

            ProcurementModels procurement = new ProcurementModels() { 
                Computer = laptopName.ToString(), 
                Quantity = quantity,
                InvoiceNo = invoiceNo,
                RequestDate = DateTime.Today
            };

            _db.ProcurementModels.Add(procurement);
            _db.SaveChanges();

            var supplier = (from c in _db.ComputerListModels where c.Name == procurement.Computer select c.SupplierName).FirstOrDefault();
            ViewBag.supplier = supplier;

            return View(procurement);
        }

        
    }
}