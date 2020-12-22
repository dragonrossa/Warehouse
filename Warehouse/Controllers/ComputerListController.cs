using Microsoft.Ajax.Utilities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class ComputerListController : Controller
    {
        //Get Computer Repository

        ComputerListRepository computerRepository = new ComputerListRepository();


        //If form count is the same and smaller than 1

        public ActionResult checkFormCount(FormCollection form)
        {
            return  form.Count <= 1 ? (ActionResult)RedirectToAction("Index", "Suppliers") : View("Index", "ComputerList");
        }

        //Check if there is item.Name
        public ActionResult checkFormName(FormCollection form)
        {
            return form["item.Name"].ToString() == null ? (ActionResult)RedirectToAction("Create", "ComputerList") : View("Index", "ComputerList");

        }

        //Check if there is SupplierName
        public ActionResult checkSupplierName(FormCollection form)
        {
            return form["SupplierName"].ToString() == null ? (ActionResult)RedirectToAction("Index", "Supplier") : View("Index", "ComputerList");

        }



        // GET: ComputerList
        [HandleError]
        public async Task<ActionResult> Index()
        {

            var computerLists = await computerRepository.computerLists();
            var suppliers = await computerRepository.suppliers();


            try
            {

                if (suppliers.Count == 0)
                {
                    return RedirectToAction("Index", "Supplier");
                }

                if(computerLists.Count == 0)
                {
                    return RedirectToAction("Create", "ComputerList");
                }

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

        public async Task<ActionResult> NotFound()
        {
            return View();
        }




        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(FormCollection form)
        {
           
            //If form count is 1 or smaller
            checkFormCount(form);

            //If form name is null
            checkFormName(form);


            //If there is SupplierName
            checkSupplierName(form);


            //Save all suppliers for all computers
            await computerRepository.saveAllRecords(form);

            return RedirectToAction("Index");

        }




        public async Task<ActionResult> ClassicView()
        {

            return View(new ComputerListModels() { suppliers = await computerRepository.suppliersforClassicView(), computers = await computerRepository.computers() });
        }


        [HttpPost]
        public async Task<ActionResult> ClassicView(FormCollection form)
        {

            //Get classic view for Computer and Suppliers
            await computerRepository.getClassicViewSuppliers(form);

            return RedirectToAction("Index");
        }




        public async Task<ActionResult> Create()
        {
            return View();
        }



        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(FormCollection form)
        {

            //Create new Computer object

           await computerRepository.createNewComputer(form);

            return RedirectToAction("Index");
        }




    }
}  