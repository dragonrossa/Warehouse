using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Helpers;
using Microsoft.AspNet.Identity;
using System.Diagnostics.Contracts;
using Warehouse.Repository;
using System.Threading.Tasks;
using Warehouse.DAL;

namespace Warehouse.Controllers
{
    public class LaptopController : Controller
    {
        //Get DB Context

        private WarehouseContext _db = new WarehouseContext();


        //Get LaptopModels object

        LaptopModels laptop = new LaptopModels();

        //Get LaptopModels list

        List<LaptopModels> listOfLaptops = new List<LaptopModels>();

        //Get Laptop Repository

        LaptopRepository laptopRepository = new LaptopRepository();

        // GET: MasterData
        public async Task<ActionResult> Index(string searchString)
        {
         
            try
            {
               

                //If there is no laptop redirect to NotFound

                if (laptop.Child == null)
                {
                    RedirectToAction("NotFound", "Laptop");
                }

 
                //if no items in list redirect to NotFound

                if (laptopRepository.lastInput == null)
                {
                    RedirectToAction("NotFound", "Laptop");
                }
                else
                {
                    ////Search box

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        var laptop = await _db.LaptopModels.Where(s => s.Name.Contains(searchString)).ToListAsync();

                        return View(new LaptopModels { laptop = laptop });


                    }

                    ViewBag.laptop = laptopRepository.lastInput.Name;
                    ViewBag.date = laptopRepository.lastInput.Date;
                    ViewBag.quantity = laptopRepository.lastInput.Quantity;
                    ViewBag.maxNumber = laptopRepository.maxNumber;
                    ViewBag.sumQuantity = laptopRepository.sumQuantity;
                    ViewBag.sumFullPrice = laptopRepository.sumFullPrice;

                    return View(new LaptopModels { laptop = laptop.Child });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);


                //redirect if there are no Laptps in list after catching exception
                if (e.Message == "Sequence contains no elements")
                {

                    //throw new UserNotFoundException();
                    return RedirectToAction("NotFound");

                }
               }

                //if there are no Laptops in list
                return View("NotFound");
           
        }



        //Exception - UserNotFound

        public async Task<ActionResult> NotFound()
        {
            return View();
        }



        //GET: MasterData/Create
        public async Task<ActionResult> Create()
        {

            return View();
        }

        //POST: MasterData/Create
        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create([Bind(Include = "Name, Details, Quantity, Manufacturer, OS, Price, OldPrice")] LaptopModels laptop)
        {
            if (ModelState.IsValid)
            {
               
                //Save in database and create new log
                await laptopRepository.createLaptop(laptop);
                return RedirectToAction("Index");
            }

          

            return View(laptop);
        }

        //GET: MasterData/List
        public async Task<ActionResult> List()
        {
           
            try
            {
             
               return View(new LaptopModels { laptop = laptopRepository.ChildByID });
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
        }

        //GET: MasterData/EditList
        public async Task<ActionResult> EditList()
        {

            try
            {
               return View(new LaptopModels { laptop = laptopRepository.ChildByID });
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

        }

        ////GET: MasterData/DeleteList
        public async Task<ActionResult> DeleteList()
        {
            
            try
            {
              return View(new LaptopModels { laptop = laptopRepository.ChildByID });
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
        }

        //GET: MasterData//5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                TempData["id"] = Convert.ToInt32(id);


                //If price changed FullPrice, Savings, PDV and FullPriceWithPDV have to change too
                laptopRepository.lastInput.FullPrice = laptopRepository.lastInputFullPrice;
                laptopRepository.lastInput.Savings = laptopRepository.lastInputSavings;
                laptopRepository.lastInput.PDV = laptopRepository.lastInputPDV;
                laptopRepository.lastInput.FullPriceWithPDV =laptopRepository.lastInputFullPriceWithPDV;

                await _db.SaveChangesAsync();
                
                if (await laptopRepository.getLaptop(id) == null)
                {
                    return HttpNotFound();
                }

                return View(await laptopRepository.getLaptop(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

          
        }

        //POST: MasterData/Edit/5
        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LaptopModels laptop)
        {

            try
            {
                if (ModelState.IsValid)
                {
                   
                    //Save changes
                     await laptopRepository.editLaptop(laptop);

                    var ID = Convert.ToInt32(TempData["id"]);

                    //find last ID and save new Savings and FullPrice

                     await laptopRepository.laptopFindAndSaveChanges(ID);

                    return RedirectToAction("Index");
                }
                return View(laptop);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

           
        }

        //GET: MasterData/Delete/5

        public async Task<ActionResult> Delete(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
      
                if (await laptopRepository.getLaptop(id) == null)
                {
                    return HttpNotFound();
                }
                return View(await laptopRepository.getLaptop(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

           
        }
        //POST: MasterData/Delete/5
        [HttpPost, ActionName("Delete")]
        [HandleError]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {

            try
            {

                //Delete laptop
                await laptopRepository.deleteLaptop(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
           
        }

        //GET: MasterData/Details/1
        public async Task<ActionResult> Details(int? id)
        {


            try
            {
                var laptopID = id;

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                if (await laptopRepository.getLaptop(id) == null)
                {
                    return HttpNotFound();
                }


                ViewBag.storeName = await laptopRepository.stores(laptopID);


                return View(await laptopRepository.getLaptop(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
            
        }

       
        //GET: MasterData/Send
        public async Task<ActionResult> Send()
        {

            try
            {

                return View(laptopRepository.ChildByIDIfNotZeroQuantity);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

        }

        //GET: MasterData/Send
        public async Task<ActionResult> SendArticle(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (await laptopRepository.getLaptop(id) == null)
                {
                    return HttpNotFound();
                }
                return View(await laptopRepository.getLaptop(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

            
        }

        //GET:MasterData/Check
        public async Task<ActionResult> Check(int? id, string name, int quantity)
        {


            try
            {
                ViewBag.id = id;
                ViewBag.name = name;
                ViewBag.number = quantity;

                TempData["id"] = id;
                TempData["name"] = name;
                TempData["number"] = quantity;
                ViewData["ddlList"] = await laptopRepository.ddlList();

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
        public async Task<ActionResult> Check(FormCollection form, TransferModels transfer)
        {

            try
            {
                int id = Convert.ToInt32(TempData["id"]);
                string name = TempData["name"].ToString();
                int quantity = Convert.ToInt32(TempData["number"]);
                int storeID = Convert.ToInt32(form["ddlList"].ToString());

                //Create new transfer
                laptopRepository.createTransfer(transfer, id, name, quantity, storeID);

                //set laptop quantity to zero
                var laptop = await laptopRepository.laptopFind(id);
                laptop.Quantity = 0;

                //reduce QoP of store for quantity number
                var store = await laptopRepository.storeFind(storeID);
                store.QoP -= quantity;
                _db.SaveChanges();

                return RedirectToAction("Index", "Transfer", new { });
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
            
        }

        public async Task<ActionResult> Company()
        {
           
            try
            {
                return View(await laptopRepository.myCompanie());
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

            
        }

        //Dispose DB
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
