using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Warehouse.DAL;
using Warehouse.Helpers;
using Warehouse.Models;
using Warehouse.Repository;
using System.Data.Entity;
using PagedList;

namespace Warehouse.Controllers
{
    public class TransferController : Controller
    {

        //Get DB Context

        private WarehouseContext _db = new WarehouseContext();

        //Get Transfer Repository
        TransferRepository transferRepository = new TransferRepository();
     
        //Get transfer object
        TransferModels transfer = new TransferModels();

      
        // GET: Index
        public async Task<ActionResult> Index(string searchString, string sortOrder, int? page)
        {


            try
            {

                ////Search box

                //if (!String.IsNullOrEmpty(searchString))
                //{
                //    var transfer = transferRepository.storeResult().Where(s => s.LaptopName.Contains(searchString));

                //    return View(new TransferResult { result = transfer });


                //}

                //Paging and search

                ViewBag.CurrentSort = sortOrder;
                ViewBag.pageNumber = page ?? 1;


                int pageSize = 10;
                int pageNumber = page ?? 1;



                //Get ViewBag.pageCount
                await transferRepository.pageCount(pageSize, transfer);

                //Search box

                if (!String.IsNullOrEmpty(searchString))
                {

                    return View(await transferRepository.transferSearch(page, searchString));
                }

                //Session for controllers

                Session["pageNumber"] = pageNumber;
                Session["pageSize"] = pageSize;

                var lastInput = transferRepository.lastInput;

                //ViewBag.store = lastInput.LaptopName;
                //ViewBag.date = lastInput.Date;
                //ViewBag.location = lastInput.Location;

                ViewBag.laptop = transferRepository.lastInput.LaptopName;
                ViewBag.date = transferRepository.lastInput.Date;
                ViewBag.quantity = transferRepository.lastInput.LaptopQuantity;

                return View(await transferRepository.pagedTransfer(page));

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


        public async Task<ActionResult> NotFound()
        {
            return View();
        }


        public async Task<ActionResult> Create()
        {
            try
            {
                ViewData["StoreName"] = await transferRepository.StoreName();
                ViewData["LaptopName"] = await transferRepository.LaptopName();

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

        public async Task<ActionResult> Create(FormCollection form, TransferModels transfer)
        {
            try
            {

               
                int LaptopID = Convert.ToInt32(form["LaptopName"].ToString());
               
               await transferRepository. createTransfer( form,  transfer,  transferRepository);


                if (await transferRepository.possibleCount(LaptopID) == 0)
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