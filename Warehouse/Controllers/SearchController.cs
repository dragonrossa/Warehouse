using System;
using System.Collections.Generic;
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
           

            return View();
        }

        [HttpPost]
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
                var searchName = (from k in _db.LaptopModels where k.Name == search.Name select k).FirstOrDefault();

                if (searchName == null)
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
                    search.LaptopName = searchName.Name;
                    search.Quantity = searchName.Quantity;
                    search.FullPrice = searchName.FullPrice;

                    
                    //Add laptop object to list

                    index.Add(search);

                    //Create new log
                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Laptop section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();

                    return View(index);
                }
            }


          
            return View();
        }


        public ActionResult SearchByManufacturer(FormCollection form)
        {
            SearchIndex search = new SearchIndex();
            List<SearchIndex> index = new List<SearchIndex>();

            if (form["manufacturer"] != null)
            {

                search.Name = form["manufacturer"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                var searchName = (from k in _db.LaptopModels where k.Manufacturer == search.Name select k).FirstOrDefault();
                int QuantityOfAllProducts = (from k in _db.LaptopModels where k.Manufacturer == search.Name select k).Count();

                //int count = _db.LaptopModels.Where(x => x.Manufacturer == search.Name).Count();

                //log for Search if not exists

                if (searchName == null)
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
                    search.LaptopName = searchName.Name;
                    search.Quantity = searchName.Quantity;
                    search.FullPrice = searchName.FullPrice;
                    search.QuantityOfAllProducts = QuantityOfAllProducts;


                    //Add laptop object to list

                    index.Add(search);

                    //Create new log
                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Laptop section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();

                    return View(index);
                }
            }

            return View();
        }


        public ActionResult SearchByOS(FormCollection form)
        {
            SearchIndex search = new SearchIndex();
            List<SearchIndex> index = new List<SearchIndex>();

            if (form["os"] != null)
            {

                search.Name = form["os"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                var searchName = (from k in _db.LaptopModels where k.OS == search.Name select k).FirstOrDefault();
                int QuantityOfAllProducts = (from k in _db.LaptopModels where k.OS == search.Name select k).Count();

                //log for Search if not exists

                if (searchName == null)
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
                    search.LaptopName = searchName.Name;
                    search.Quantity = searchName.Quantity;
                    search.FullPrice = searchName.FullPrice;
                    search.QuantityOfAllProducts = QuantityOfAllProducts;


                    //Add laptop object to list

                    index.Add(search);

                    //Create new log
                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Laptop section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();

                    return View(index);
                }
            }

            return View();
        }



        public ActionResult SearchStore(FormCollection form)
        {
            SearchIndex search = new SearchIndex();
            List<SearchIndex> index = new List<SearchIndex>();

           if (form["storeName"] != null){

                search.Name = form["storeName"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                var searchName = (from k in _db.StoreModels where k.Name == search.Name select k).FirstOrDefault();
                if (searchName == null)
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
                    //Create Store object
                    search.StoreName = searchName.Name;
                    search.StoreAddress = searchName.Address;
                    search.StoreLocation = searchName.Location;

                    //Add store object to list
                    index.Add(search);
                    //Create new log
                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Store section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultStore", index);
                }
            }
            return View();
        }

        public ActionResult SearchTransfer(FormCollection form)
        {
            SearchIndex search = new SearchIndex();
            List<SearchIndex> index = new List<SearchIndex>();

            //Search for Store

            if (form["laptopName"] != null)
            {
                search.Name = form["laptopName"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                var searchName = (from k in _db.TransferModels where k.LaptopName == search.Name select k).FirstOrDefault();
                if (searchName == null)
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
                    var store = (from k in _db.StoreModels where k.ID == searchName.StoreID select k.Name).FirstOrDefault();
                    //Create Store object
                    search.TransferLaptopName = searchName.LaptopName;
                    search.TransferLaptopQuantity = searchName.LaptopQuantity;
                    search.TransferStoreName = store;

                    //Add store object to list
                    index.Add(search);
                    LogModels log = new LogModels
                    {
                        Type = "3",
                        Description = "There was new search in Transfer section for " + search.Name + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return View("ResultTransfer", index);
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