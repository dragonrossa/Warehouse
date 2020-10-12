using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class ComputerListController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: ComputerList
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<SelectListItem> computers = _db.ComputerListModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();


            //Suppliers Select List Item
            List<SelectListItem> suppliers = _db.SupplierModels.ToList().Select(u => new SelectListItem
            {
                Text = u.SupplierName,
                Value = u.ID.ToString()
            }).ToList();


            return View(new ComputerListModels() { suppliers = suppliers, computers = computers });
        }


        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {
            var computerName = form["item.Text"].ToString();
            string supplierName = form["SupplierName"].ToString();

            string[] computers = computerName.Split(',');



            string[] sup = supplierName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);


            string comp;
            string supName;



            for (int i = 0; i < computers.Length; i++)
            {
                comp = computers[i];
                supName = sup[i];
                var computerFind = (from c in _db.ComputerListModels where c.Name == comp select c).FirstOrDefault();
                computerFind.SupplierID = Convert.ToInt32(supName);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");

        }




        public ActionResult ClassicView()
        {

            List<SelectListItem> computers = _db.ComputerListModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();


            //Suppliers Select List Item
            List<SelectListItem> suppliers = _db.SupplierModels.ToList().Select(u => new SelectListItem
            {
                Text = u.SupplierName,
                Value = u.ID.ToString()
            }).ToList();



            return View(new ComputerListModels() { suppliers = suppliers, computers = computers });
        }


        [HttpPost]
        public ActionResult ClassicView(FormCollection form)
        {
            var computerName = form["Name"].ToString();
            var supplierName = form["SupplierName"].ToString();



            int cName = Convert.ToInt32(computerName.Remove(computerName.Length - 1));
            int sName = Convert.ToInt32(supplierName.Remove(supplierName.Length - 1));


            ComputerListModels computerLists = (from e in _db.ComputerListModels
                                                where e.ID == cName
                                                select e).FirstOrDefault();
            computerLists.SupplierID = sName;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }




    }
}  