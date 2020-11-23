using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class SupplierController : Controller
    {

        //Get Supplier Repository
        SupplierRepository supplierRepository = new SupplierRepository();

        //Create new supplier object
        SupplierModels supplier = new SupplierModels();


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

            supplierRepository.newSupplier(supplier);

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

            supplierRepository.editSupplier(form);

            return RedirectToAction("Index","ComputerList");
        }


        public ActionResult Delete(int? id)
        {

            //Delete Supplier

            supplierRepository.deleteSupplier(id);

            return RedirectToAction("Index", "ComputerList");
        }
    }
}