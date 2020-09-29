using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Warehouse.Helpers;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Search
        //Search - Laptop
        //Search - Store
        //Search - Transfer

        //Example 1. search for Notebook Acer Aspire 1 in Laptop section
        //Example 2. search for SD Store Zadar in Store section
        //Example 3. search for Notebook HP 250-G7 in Transfers
        public ActionResult Index()
        {
            var user = User.Identity.GetUserName();

            bool access = (from a in _db.AdminModels where a.Username == user select a.SearchAccess).FirstOrDefault();

            bool fal = false;

            if (access == fal)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return RedirectToAction("Index", "Laptop");
            }
            else
            {


                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Result(FormCollection form)
        {
            SearchIndex search = new SearchIndex();
            List<SearchIndex> index = new List<SearchIndex>();

            //Search for Laptop


            if (form["name"] != null)
            {

                search.Name = form["name"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                ViewBag.searchname = (from k in _db.LaptopModels where k.Name == search.Name select k).FirstOrDefault();
                int QuantityOfAllProducts = (from k in _db.LaptopModels where k.Name == search.Name select k).Count();
                List<LaptopModels> laptops = (from k in _db.LaptopModels where k.Name == search.Name select k).ToList();
                search.QuantityOfAllProducts = (from k in _db.LaptopModels where k.Name == search.Name select k).Count();
                ViewBag.quantity = (from k in _db.LaptopModels where k.Name == search.Name select (int?)k.Quantity).Sum();


                if (ViewBag.searchname == null)
                {
                    LogModels log = new LogModels
                    {
                        Type = "4",
                        Description = "There was new search in Transfer section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultNotExists");
                }

                else
                {
                   

                    //Create new log
                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Laptop section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();

                    return View(laptops);
                }
            }


          
            return View();
        }


        public ActionResult SearchByManufacturer(FormCollection form)
        {
            SearchIndex search = new SearchIndex();
         

            if (form["manufacturer"] != null)
            {

                search.Name = form["manufacturer"];
                ViewBag.Name = form["manufacturer"];
                TempData["searchName"] = ViewBag.Name;
                ViewBag.searchname = (from k in _db.LaptopModels where k.Manufacturer == search.Name select k).FirstOrDefault();
                int QuantityOfAllProducts = (from k in _db.LaptopModels where k.Manufacturer == search.Name select k).Count();
                search.QuantityOfAllProducts = (from k in _db.LaptopModels where k.OS == search.Name select k).Count();
                List<LaptopModels> laptops = (from k in _db.LaptopModels where k.Manufacturer == search.Name select k).ToList();
                ViewBag.quantity = (from k in _db.LaptopModels where k.Manufacturer == search.Name select (int?)k.Quantity).Sum();

                //int count = _db.LaptopModels.Where(x => x.Manufacturer == search.Name).Count();

                //log for Search if not exists

                if (ViewBag.searchname == null)
                {
                    LogModels log = new LogModels
                    {
                        Type = "4",
                        Description = "There was new search in Transfer section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultNotExists");
                }

                else
                {
                  

                    //Create new log
                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Laptop section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();

                    return View(laptops);
                }
            }

            return View();
        }


        public ActionResult SearchByOS(FormCollection form)
        {
            SearchIndex search = new SearchIndex();
           // List<SearchIndex> index = new List<SearchIndex>();
            

            if (form["os"] != null)
            {

                search.Name = form["os"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                ViewBag.searchName = (from k in _db.LaptopModels where k.OS == search.Name select k).FirstOrDefault();
                int QuantityOfAllProducts = (from k in _db.LaptopModels where k.OS == search.Name select k).Count();
                search.QuantityOfAllProducts = (from k in _db.LaptopModels where k.OS == search.Name select k).Count();
                ViewBag.quantity = (from k in _db.LaptopModels where k.OS == search.Name select (int?)k.Quantity).Sum();

                List<LaptopModels> laptops = (from k in _db.LaptopModels where k.OS == search.Name select k).ToList();

                //log for Search if not exists

                if (ViewBag.searchname == null)
                {
                    LogModels log = new LogModels
                    {
                        Type = "4",
                        Description = "There was new search in Transfer section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultNotExists");
                }

                else
                {
                    //Create Laptop object
                    

                    //Add laptop object to list

        
                    //Create new log
                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Laptop section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();

                    return View(laptops);
                }
            }

            return View();
        }



        public ActionResult SearchStore(FormCollection form)
        {
            SearchIndex search = new SearchIndex();
         

           if (form["storeName"] != null){

                search.Name = form["storeName"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                ViewBag.searchName = (from k in _db.StoreModels where k.Name == search.Name select k).FirstOrDefault();
                List<StoreModels> stores = (from k in _db.StoreModels where k.Name == search.Name select k).ToList();
                ViewBag.quantity = (from k in _db.StoreModels where k.Name == search.Name select (int?)k.QoP).Sum();

                if (ViewBag.searchName == null)
                {
                    LogModels log = new LogModels
                    {
                        Type = "4",
                        Description = "There was new search in Transfer section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultNotExists");
                }
                else
                {
                  
                    //Create new log
                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Store section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultStore",stores);
                }
            }
            return View();
        }

        public ActionResult SearchStoreByLocation(FormCollection form)
        {
            SearchIndex search = new SearchIndex();


            if (form["storeLocation"] != null)
            {

                search.Name = form["storeLocation"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                ViewBag.searchName = (from k in _db.StoreModels where k.Location == search.Name select k).FirstOrDefault();
                List<StoreModels> stores = (from k in _db.StoreModels where k.Location == search.Name select k).ToList();
                ViewBag.quantity = (from k in _db.StoreModels where k.Location == search.Name select (int?)k.QoP).Sum();

                if (ViewBag.searchName == null)
                {
                    LogModels log = new LogModels
                    {
                        Type = "4",
                        Description = "There was new search in Transfer section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultNotExists");
                }
                else
                {

                    //Create new log
                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Store section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultStore", stores);
                }
            }
            return View();

        }

        public ActionResult SearchStoreByZipCode(FormCollection form)
        {
            SearchIndex search = new SearchIndex();


            if (form["storeZipcode"] != null)
            {
                
                search.Name = form["storeZipcode"];
                int? test = Convert.ToInt32(search.Name);
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                ViewBag.searchName = (from k in _db.StoreModels where k.ZipCode == test select k).FirstOrDefault();
                List<StoreModels> stores = (from k in _db.StoreModels where k.ZipCode == test select k).ToList();
                ViewBag.quantity = (from k in _db.StoreModels where k.ZipCode == test select (int?)k.QoP).Sum();

                if (ViewBag.searchName == null)
                {
                    LogModels log = new LogModels
                    {
                        Type = "4",
                        Description = "There was new search in Transfer section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultNotExists");
                }
                else
                {

                    //Create new log
                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Store section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultStore", stores);
                }
            }

            return View();
        }

        public ActionResult SearchTransfer(FormCollection form)
        {
            SearchIndex search = new SearchIndex();
         

            //Search for Store

            if (form["laptopName"] != null)
            {
                search.Name = form["laptopName"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                ViewBag.searchname = (from k in _db.TransferModels where k.LaptopName == search.Name select k).FirstOrDefault();
                ViewBag.quantity = (from k in _db.TransferModels where k.LaptopName == search.Name select (int?)k.LaptopQuantity).Sum();
                List<TransferModels> transfers = (from k in _db.TransferModels where k.LaptopName == search.Name select k).ToList();

                if (ViewBag.searchname == null && ViewBag.quantity == null)
                {
                    LogModels log = new LogModels
                    {
                        Type = "4",
                        Description = "There was new search in Transfer section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultNotExists");
                }
                else
                {
               
                    //Add store object to list
                
                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Transfer section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultTransfer",transfers);
                }
            }
         
            return View();
        }

        public ActionResult SearchTransferByStoreName(FormCollection form)
        {
            SearchIndex search = new SearchIndex();
            //Search for Store

            if (form["storeName"] != null)
            {
                search.Name = form["storeName"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;

                //check by storeName


                //First find storeID

                int storeID = (from s in _db.StoreModels
                               where s.Name == search.Name
                               select s.ID).SingleOrDefault();

                //then find store name

            

                List <TransferModels> transfers = (from t in _db.TransferModels
                                    where t.StoreID == storeID
                                    select t).ToList();

                //write down name for store

                ViewBag.searchname = (from t in _db.TransferModels
                                      where t.StoreID == storeID
                                      select t).FirstOrDefault();

                ViewBag.quantity = (from t in _db.TransferModels
                                    where t.StoreID == storeID
                                    select (int?)t.LaptopQuantity).Sum();


                if (ViewBag.searchname == null && ViewBag.quantity == null)
                {
                    LogModels log = new LogModels
                    {
                        Type = "4",
                        Description = "There was new search in Transfer section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultNotExists");
                }
                else
                {


                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Transfer section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultTransfer", transfers);
                }
            }

            return View();
        }



        public ActionResult ResultNotExists()
        {
            
            return View();
        }
    }
}