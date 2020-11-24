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

namespace Warehouse.Controllers
{
    public class LaptopController : Controller
    {
        //Get DB Context

        private ApplicationDbContext _db = new ApplicationDbContext();

        //Get LaptopModels object

        LaptopModels laptop1 = new LaptopModels();

        //Get LaptopModels list

        List<LaptopModels> listOfLaptops = new List<LaptopModels>();

        //Get Laptop Repository

        LaptopRepository laptopRepository = new LaptopRepository();

       

        // GET: MasterData
        public ActionResult Index()
        {
         
            try
            {

                if (laptop1.Child == null)
                {
                    RedirectToAction("NotFound", "Laptop");
                }

 
                //if no items in list redirect to NotFound

                if (laptop1.lastInput == null)
                {
                    RedirectToAction("NotFound", "Laptop");
                }
                else
                {

                  
                    ViewBag.laptop = laptop1.lastInput.Name;
                    ViewBag.date = laptop1.lastInput.Date;
                    ViewBag.quantity = laptop1.lastInput.Quantity;
                    ViewBag.maxNumber = laptop1.maxNumber;
                    ViewBag.sumQuantity = laptop1.sumQuantity;
                    ViewBag.sumFullPrice = laptop1.sumFullPrice;


                    return View(new LaptopModels { laptop = laptop1.Child });
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

        public ActionResult NotFound()
        {
            return View();
        }


        public ActionResult AscName()
        {
           
          return View("Index", new LaptopModels { laptop = laptop1.AscendingByName });
        }

        public ActionResult DescName()
        {
          return View("Index", new LaptopModels { laptop = laptop1.DescendingByName });
        }


        public ActionResult AscQuantity()
        {
          return View("Index", new LaptopModels { laptop = laptop1.AscendingByQuantity });
        }

        public ActionResult DescQuantity()
        {
          return View("Index", new LaptopModels { laptop = laptop1.DescendingByQuantity });
        }

        public ActionResult AscPrice()
        {
          return View("Index", new LaptopModels { laptop = laptop1.AscendingByPrice });
        }

        public ActionResult DescPrice()
        {
          return View("Index", new LaptopModels { laptop = laptop1.DescendingByPrice });
        }


        public ActionResult AscFullPrice()
        {
          return View("Index", new LaptopModels { laptop = laptop1.AscendingByFullPrice });
        }

        public ActionResult DescFullPrice()
        {
         return View("Index", new LaptopModels { laptop = laptop1.DescendingByFullPrice });
        }


        //GET: MasterData/Create
        public ActionResult Create()
        {

            return View();
        }

        //POST: MasterData/Create
        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LaptopModels laptop)
        {
            if (ModelState.IsValid)
            {
                //_db.LaptopModels.Add(laptop);
                //_db.SaveChanges();

                ////Last input in database
                //var lastInput = laptop1.lastInput;

                //lastInput.FullPrice = laptop1.lastInputFullPrice;
                //lastInput.Savings = laptop1.lastInputSavings;
                //lastInput.Date = laptop1.lastInputDate;
                //_db.SaveChanges();

                ////Create new log

                //laptop1.CreateLog(lastInput.Name, lastInput.Date, lastInput.Quantity);

                //Save in database and create new log
                laptopRepository.createLaptop(laptop, laptop1);
                return RedirectToAction("Index");
            }

          

            return View(laptop);
        }

        //GET: MasterData/List
        public ActionResult List()
        {
           
            try
            {
             
               return View(laptop1.ChildByID);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
        }

        //GET: MasterData/EditList
        public ActionResult EditList()
        {

            try
            {
               return View(laptop1.ChildByID);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

        }

        ////GET: MasterData/DeleteList
        public ActionResult DeleteList()
        {
            
            try
            {
              return View(laptop1.ChildByID);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
        }

        //GET: MasterData/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //LaptopModels laptop = _db.LaptopModels.Find(id);

                //var idUser = Convert.ToInt32(id);

                TempData["id"] = Convert.ToInt32(id);

                //If price changed FullPrice and Savings have to change too
                laptop1.lastInput.FullPrice = laptop1.lastInput.lastInputFullPrice;
                laptop1.lastInput.Savings = laptop1.lastInput.lastInputSavings;
                _db.SaveChanges();
                
                if (laptopRepository.getLaptop(id) == null)
                {
                    return HttpNotFound();
                }

                return View(laptopRepository.getLaptop(id));
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
        public ActionResult Edit(LaptopModels laptop)
        {

            try
            {
                if (ModelState.IsValid)
                {
                   
                    //Save changes
                    laptopRepository.editLaptop(laptop);

                    var ID = Convert.ToInt32(TempData["id"]);

                    //find last ID and save new Savings and FullPrice
                    laptopRepository.
                    laptopFind(ID).Savings = laptopRepository.laptopFindSavings(ID);
                    laptopRepository.laptopFind(ID).FullPrice = laptopRepository.laptopFindFullPrice(ID);


                    _db.SaveChanges();

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

        public ActionResult Delete(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //LaptopModels laptop = _db.LaptopModels.Find(id);

                //laptopRepository.getLaptop(id);

                if (laptopRepository.getLaptop(id) == null)
                {
                    return HttpNotFound();
                }
                return View(laptopRepository.getLaptop(id));
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
        public ActionResult Delete(int id)
        {

            try
            {
                //LaptopModels laptop = _db.LaptopModels.Find(id);
                //_db.LaptopModels.Remove(laptop);
                //_db.SaveChanges();

                //Delete laptop
                laptopRepository.deleteLaptop(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
           
        }

        //GET: MasterData/Details/1
        public ActionResult Details(int? id)
        {


            try
            {
                var laptopID = id;

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                //LaptopModels laptop = _db.LaptopModels.Find(id);

                if (laptopRepository.getLaptop(id) == null)
                {
                    return HttpNotFound();
                }



                ViewBag.storeName = laptopRepository.stores(laptopID);


                return View(laptopRepository.getLaptop(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
            
        }

        public ActionResult Result()
        {


            try
            {
                var laptop = (from k in _db.LaptopModels select k).ToList();

                var result = (from k in _db.LaptopModels select k.Price * k.Quantity).ToList();


                foreach (var lap in laptop)
                {

                    foreach (var res in result)
                    {

                        lap.FullPrice = Convert.ToDecimal(res);

                        _db.SaveChanges();

                    }

                }


                ViewBag.selectResult = "abcd";



                return View(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

            
        }


        //GET: MasterData/Send
        public ActionResult Send()
        {

            try
            {

                return View(laptop1.ChildByIDIfNotZeroQuantity);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

        }

        //GET: MasterData/Send
        public ActionResult SendArticle(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //LaptopModels laptop = _db.LaptopModels.Find(id);

                if (laptopRepository.getLaptop(id) == null)
                {
                    return HttpNotFound();
                }
                return View(laptopRepository.getLaptop(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

            
        }

        //GET:MasterData/Check
        public ActionResult Check(int? id, string name, int quantity)
        {


            try
            {
                ViewBag.id = id;
                ViewBag.name = name;
                ViewBag.number = quantity;

                TempData["id"] = id;
                TempData["name"] = name;
                TempData["number"] = quantity;


                ViewData["ddlList"] = laptopRepository.ddlList();
                //    _db.StoreModels.ToList().Select(u => new SelectListItem
                //{
                //    Text = u.Name,
                //    Value = u.ID.ToString()
                //}).ToList();


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
        public ActionResult Check(FormCollection form, TransferModels transfer)
        {

            try
            {
                int id = Convert.ToInt32(TempData["id"]);
                string name = TempData["name"].ToString();
                int quantity = Convert.ToInt32(TempData["number"]);
                int storeID = Convert.ToInt32(form["ddlList"].ToString());

                //Create new Transfer
                transfer.LaptopID = id;
                transfer.LaptopName = name;
                transfer.LaptopQuantity = quantity;
                transfer.StoreID = storeID;
                transfer.Date = DateTime.Now;// add if any field you want insert
                _db.TransferModels.Add(transfer);           // pass the table object 

                //set laptop quantity to zero
                laptopRepository.laptopFind(id).Quantity = 0;
               //reduce QoP of store for quantity number
                laptopRepository.storeFind(storeID).QoP -= quantity;
                _db.SaveChanges();

                return RedirectToAction("Index", "Transfer", new { });
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
            
        }

        public ActionResult Company()
        {

            try
            {
                Company company = new Company
                {

                    Name = "Abeceda d.o.o.",
                    Street = "Ruđera Boškovića 32",
                    Town = "Zagreb",
                    ZipCode = "10000",
                    Country = "Croatia",
                    OIB = "123123123"
                };


                List<Company> companies = new List<Company>
            {
                company
            };

                return View(companies);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

            
        }
    }
}
