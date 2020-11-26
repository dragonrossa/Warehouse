using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Warehouse.Helpers;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class TransferController : Controller
    {
        //Get Transfer Repository
        TransferRepository transferRepository = new TransferRepository();
     
        //Get transfer object
        TransferModels transfer = new TransferModels();

      
        // GET: Index
        public ActionResult Index()
        {
          

                try
                {

                ViewBag.laptop = transferRepository.lastInput.LaptopName;
                ViewBag.date = transferRepository.lastInput.Date;
                ViewBag.quantity = transferRepository.lastInput.LaptopQuantity;
               
                return View(transferRepository.storeResult());
                }
                catch (Exception e)
               {
                    Console.WriteLine("{0} Exception caught.", e);

                if (e.Message =="Sequence contains no elements")
                {

                    //throw new UserNotFoundException();
                    // throw;
                    return RedirectToAction("NotFound");

                }
               
              return View();
            }
        }


        public ActionResult NotFound()
        {
            return View();
        }


        public ActionResult Create()
        {
            try
            {
                ViewData["StoreName"] = transferRepository.StoreName();
                ViewData["LaptopName"] = transferRepository.LaptopName();

                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
           
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]

        public ActionResult Create(FormCollection form, TransferModels transfer)
        {
            try
            {

               
                int LaptopID = Convert.ToInt32(form["LaptopName"].ToString());
               
               transferRepository. createTransfer( form,  transfer,  transferRepository);


                if (transferRepository.possibleCount(LaptopID) == 0)
                {
                    return RedirectToAction("Index", "Laptop", new { });
                }



                return RedirectToAction("Index", "Transfer", new { });
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

          
        }

       
    }
}