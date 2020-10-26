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

namespace Warehouse.Controllers
{
    public class LaptopController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();


      //  Custom Exception for UserNotFound

        public class UserNotFoundException : Exception
        {
            public UserNotFoundException() : base() { }
            public UserNotFoundException(string message) : base(message) { }
            public UserNotFoundException(string message, Exception innerException)
                : base(message, innerException) { }
        }

        // GET: MasterData
        public ActionResult Index()
        {
            var user = User.Identity.GetUserName();


            try
            {

                List<LaptopModels> laptop = _db.LaptopModels.ToList().
                                            OrderBy(u => u.ID).
                                            Select(u => u).ToList();

                if(laptop == null)
                {
                    RedirectToAction("NotFound", "Laptop");
                }

                var lastInput = (from k in _db.LaptopModels
                                 select k)
                                .OrderByDescending(k => k.ID)
                                .FirstOrDefault();

                //if no items in list redirect to NotFound

                if (lastInput == null)
                {
                    RedirectToAction("NotFound", "Laptop");
                }
                else
                {

                    ViewBag.laptop = lastInput.Name;
                    ViewBag.date = lastInput.Date;
                    ViewBag.quantity = lastInput.Quantity;

                    var maxNumber = laptop.Sum(d => d.Savings);

                    var sumQuantity = laptop.Sum(d => d.Quantity);

                    var sumFullPrice = laptop.Sum(d => d.FullPrice);

                    ViewBag.maxNumber = maxNumber;
                    ViewBag.sumQuantity = sumQuantity;
                    ViewBag.sumFullPrice = sumFullPrice;

                    return View(new LaptopModels { laptop = laptop });
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


                //  catch(UserNotFoundException abcd)
                //{
                //    Console.WriteLine("{0} User not found exception caught ", abcd);
                //}

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
            List<LaptopModels> laptop = _db.LaptopModels.ToList().OrderBy(u => u.Name).Select(u => u).ToList();

            return View("Index", new LaptopModels { laptop = laptop});
        }

        public ActionResult DescName()
        {
            List<LaptopModels> laptop = _db.LaptopModels.ToList().OrderByDescending(u => u.Name).Select(u=>u).ToList();

            return View("Index", new LaptopModels { laptop = laptop });
        }


        public ActionResult AscQuantity()
        {
            List<LaptopModels> laptop = _db.LaptopModels.ToList().OrderBy(u => u.Quantity).Select(u => u).ToList();

            return View("Index", new LaptopModels { laptop = laptop });
        }

        public ActionResult DescQuantity()
        {
            List<LaptopModels> laptop = _db.LaptopModels.ToList().OrderByDescending(u => u.Quantity).Select(u => u).ToList();

            return View("Index", new LaptopModels { laptop = laptop });
        }

        public ActionResult AscPrice()
        {
            List<LaptopModels> laptop = _db.LaptopModels.ToList().OrderBy(u => u.Price).Select(u => u).ToList();

            return View("Index", new LaptopModels { laptop = laptop });
        }

        public ActionResult DescPrice()
        {
            List<LaptopModels> laptop = _db.LaptopModels.ToList().OrderByDescending(u => u.Price).Select(u => u).ToList();

            return View("Index", new LaptopModels { laptop = laptop });
        }


        public ActionResult AscFullPrice()
        {
            List<LaptopModels> laptop = _db.LaptopModels.ToList().OrderBy(u => u.FullPrice).Select(u => u).ToList();

            return View("Index", new LaptopModels { laptop = laptop });
        }

        public ActionResult DescFullPrice()
        {
            List<LaptopModels> laptop = _db.LaptopModels.ToList().OrderByDescending(u => u.FullPrice).Select(u => u).ToList();

            return View("Index", new LaptopModels { laptop = laptop });
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
                _db.LaptopModels.Add(laptop);
                _db.SaveChanges();

                var lastInput = (from k in _db.LaptopModels
                                 select k)
                           .OrderByDescending(k => k.ID)
                           .First();

              
                lastInput.FullPrice = (from k in _db.LaptopModels where k.ID == lastInput.ID select k.Price * k.Quantity).First(); //Full price of products
                lastInput.Savings = (from k in _db.LaptopModels where k.ID == lastInput.ID select k.OldPrice - k.Price).First(); // Savings per unit
                lastInput.Date = DateTime.Now;  // add Date time now
                _db.SaveChanges();

                //Create new log
                LogModels log = new LogModels {
                    Type="0",
                    Description = "New laptop was inserted with name " + lastInput.Name + " on date " + lastInput.Date + " with quantity of " + lastInput.Quantity + ".",
                    Date = lastInput.Date
                    };

                _db.LogModels.Add(log);
                _db.SaveChanges();
                

                return RedirectToAction("Index");
            }

          

            return View(laptop);
        }

        //GET: MasterData/List
        public ActionResult List()
        {
           
            try
            {
                List<LaptopModels> laptop = _db.LaptopModels.ToList().OrderBy(u => u.ID).Select(u => u).ToList();
                return View(laptop);
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
                List<LaptopModels> laptop = _db.LaptopModels.ToList().OrderBy(u => u.ID).Select(u => u).ToList();
                return View(laptop);
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
                List<LaptopModels> laptop = _db.LaptopModels.ToList().OrderBy(u => u.ID).Select(u => u).ToList();
                return View(laptop);
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
                LaptopModels laptop = _db.LaptopModels.Find(id);

                var idUser = Convert.ToInt32(id);

                TempData["id"] = idUser;

                //Update Full price if price changed in meanwhile

                var result = (from k in _db.LaptopModels where k.ID == idUser select k.Price * k.Quantity).First(); //select price

                var savings = (from k in _db.LaptopModels where k.ID == idUser select k.OldPrice - k.Price).First();

                var laptopFind = (from k in _db.LaptopModels where k.ID == idUser select k).First(); //select laptop

                laptopFind.FullPrice = Convert.ToDecimal(result); // update FullPrice

                laptopFind.Savings = Convert.ToDecimal(savings);

                _db.SaveChanges();

                if (laptop == null)
                {
                    return HttpNotFound();
                }


                return View(laptop);
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
                    _db.Entry(laptop).State = EntityState.Modified;
                    _db.SaveChanges();

                    var id = Convert.ToInt32(TempData["id"]);

                    var savings = (from k in _db.LaptopModels where k.ID == id select k.OldPrice - k.Price).First(); //calculate saving

                    var result = (from k in _db.LaptopModels where k.ID == id select k.Price * k.Quantity).First(); //calculate new full price

                    var laptopFind = (from k in _db.LaptopModels where k.ID == id select k).First(); //select laptop

                    laptopFind.Savings = Convert.ToDecimal(savings); //EF Savings

                    laptopFind.FullPrice = Convert.ToDecimal(result);

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
                LaptopModels laptop = _db.LaptopModels.Find(id);

                if (laptop == null)
                {
                    return HttpNotFound();
                }
                return View(laptop);
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
                LaptopModels laptop = _db.LaptopModels.Find(id);
                _db.LaptopModels.Remove(laptop);
                _db.SaveChanges();
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

                LaptopModels laptop = _db.LaptopModels.Find(id);

                if (laptop == null)
                {
                    return HttpNotFound();
                }


                //var query = (from t in _db.TransferModels
                //             join s in _db.StoreModels on t.StoreID equals s.ID
                //             where t.LaptopID == laptopID
                //             select s.Name).SingleOrDefault();


                //List of stores


                var stores = (from t in _db.TransferModels
                                       join s in _db.StoreModels on t.StoreID
                                       equals s.ID
                                       where t.LaptopID == laptopID
                                       select s.Name).ToList();

                
                ViewBag.storeName = stores.Count == 0 ? ViewBag.storeName = stores : ViewBag.storeName = stores;

                return View(laptop);
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

                List<LaptopModels> laptop = _db.LaptopModels.ToList().OrderBy(u => u.ID).Select(u => u).ToList();
                var newList = laptop.Where(i => i.Quantity != 0).ToList();
                return View(newList);
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
                LaptopModels laptop = _db.LaptopModels.Find(id);

                if (laptop == null)
                {
                    return HttpNotFound();
                }
                return View(laptop);
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


                ViewData["ddlList"] = _db.StoreModels.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString()
                }).ToList();


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
                transfer.LaptopID = id;
                transfer.LaptopName = name;
                transfer.LaptopQuantity = quantity;
                transfer.StoreID = storeID;
                transfer.Date = DateTime.Now;// add if any field you want insert
                _db.TransferModels.Add(transfer);           // pass the table object 
                var laptopFind = (from k in _db.LaptopModels where k.ID == id select k).First(); //select laptop
                laptopFind.Quantity = 0;  //put quantity to 0
                var storeFind = (from s in _db.StoreModels where s.ID == storeID select s).First(); //select store, change Qop
                storeFind.QoP = storeFind.QoP - quantity; // reduce QoP for quantity number
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
