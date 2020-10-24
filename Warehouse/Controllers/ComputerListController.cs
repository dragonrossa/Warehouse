using Microsoft.Ajax.Utilities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class ComputerListController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public class UserNotFoundException : Exception
        {
            public UserNotFoundException() : base() { }
            public UserNotFoundException(string message) : base(message) { }
            public UserNotFoundException(string message, Exception innerException)
                : base(message, innerException) { }
        }

        // GET: ComputerList
        [HandleError]
        public ActionResult Index()
        {


            try
            {

                //Computers Select List Item

                List<ComputerListModels> computerLists = (from c in _db.ComputerListModels select c).ToList();


                //Suppliers Select List Item
                List<SelectListItem> suppliers = _db.SupplierModels.ToList().Select(u => new SelectListItem
                {
                    Text = u.SupplierName,
                    Value = u.ID.ToString()
                }).ToList();



                return View(new ComputerListModels() { suppliers = suppliers, computersList = computerLists });
            }
            catch (Exception e)
            {
                //redirect if there are no Laptopmodels in list
                if (e.Message == "Sequence contains no elements")
                {

                    //throw new UserNotFoundException();
                    // throw;
                    return RedirectToAction("NotFound");

                }
            }


            return View();

           

        }


        //Exception - UserNotFound

        public ActionResult NotFound()
        {
            return View();
        }




        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {
            var computerName = form["item.Name"].ToString();
            string supplierName = form["SupplierName"].ToString();

            string[] computers = computerName.Split(',');



            string[] sup = supplierName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);


            string comp;
            string supName;
            int supi;



            for (int i = 0; i < computers.Length; i++)
            {
                comp = computers[i];
                supName = sup[i];
                supi = Convert.ToInt32(supName);
                var computerFind = (from c in _db.ComputerListModels where c.Name == comp select c).FirstOrDefault();
                var suppliersName = (from s in _db.SupplierModels where s.ID == supi select s).FirstOrDefault();
                computerFind.SupplierID = Convert.ToInt32(supName);
                computerFind.SupplierName = suppliersName.SupplierName;
                _db.SaveChanges();
            }

            return RedirectToAction("Index");

        }




        public ActionResult ClassicView()
        {

            //Select list for all users
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

            var supplier = (from e in _db.SupplierModels
                            where e.ID == sName
                            select e).FirstOrDefault();

            computerLists.SupplierID = sName;
            computerLists.SupplierName = supplier.SupplierName;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }




    }
}  