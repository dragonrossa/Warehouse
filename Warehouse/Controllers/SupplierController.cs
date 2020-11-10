using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class SupplierController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //Create new supplier object
        SupplierModels supplier = new SupplierModels();

        //Create Supplier
        public SupplierModels newSupplier(SupplierModels supplier)
        {

            if (ModelState.IsValid)
            {
                _db.SupplierModels.Add(supplier);
                _db.SaveChanges();
            }

            return supplier;
        }



    //Edit Supplier
    void editSupplier(FormCollection form)
        {
            var supplierName = form["item.SupplierName"];
            var location = form["item.Location"];
            string[] suppliers = supplierName.Split(',');
            string[] suppliersLocation = location.Split(',');

            string supName;

            for (int i = 0; i < suppliers.Length; i++)
            {
                supName = suppliers[i];
                var suppliers1 = (from s in _db.SupplierModels where s.SupplierName == supName select s).FirstOrDefault();
                suppliers1.SupplierName = suppliers[i];
                suppliers1.Location = suppliersLocation[i];
                _db.SaveChanges();
            }

        }

        //Delete Supplier
        void deleteSupplier(int? id)
        {

            var supplier = (from s in _db.SupplierModels
                            where s.ID == id
                            select s).FirstOrDefault();

            _db.SupplierModels.Remove(supplier);
            _db.SaveChanges();
        }


       // GET: Supplier
        public ActionResult Index()
        {

            try
            {
                return View(new SupplierModels { suppliers = supplier.Child });
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierModels supplier)
        {
            //Create new supplier

            newSupplier(supplier);

            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            return View(new SupplierModels { suppliers = supplier.Child });
        }
     

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            //Save new informations for Suppliers
            editSupplier(form);

            return RedirectToAction("Index","ComputerList");
        }


        public ActionResult Delete(int? id)
        {

            //Delete Supplier
            deleteSupplier(id);

            return RedirectToAction("Index", "ComputerList");
        }
    }
}