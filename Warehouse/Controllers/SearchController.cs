using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Warehouse.Helpers;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class SearchController : Controller
    {
        //Call database
        private ApplicationDbContext _db = new ApplicationDbContext();

        //Create class object
        SearchIndex search = new SearchIndex();

        //Initialize new Search List
        List<SearchIndex> index = new List<SearchIndex>();


        //If needed, user info
        public string userInfo()
        {
            var user = User.Identity.GetUserName();
            return user;
        }

        
        public List<LaptopModels> findSearch(SearchIndex search)
        {

            int QuantityOfAllProducts = (from k in _db.LaptopModels
                                         where k.Manufacturer == search.Name 
                                         select k).Count();
            search.QuantityOfAllProducts = (from k in _db.LaptopModels 
                                            where k.OS == search.Name 
                                            select k).Count();
            List<LaptopModels> laptops = (from k in _db.LaptopModels 
                                          where k.Manufacturer == search.Name 
                                          select k).ToList();
            return laptops;

        }

        public List<LaptopModels> findSearchOS(SearchIndex search)
        {


            int QuantityOfAllProducts = (from k in _db.LaptopModels 
                                         where k.OS == search.Name 
                                         select k).Count();
            search.QuantityOfAllProducts = (from k in _db.LaptopModels 
                                            where k.OS == search.Name 
                                            select k).Count();
            List<LaptopModels> laptops = (from k in _db.LaptopModels 
                                          where k.OS == search.Name 
                                          select k).ToList();
            return laptops;

        }

        public List<StoreModels> findSearchLocation(SearchIndex search)
        {

            List<StoreModels> stores = (from k in _db.StoreModels 
                                        where k.Location == search.Name 
                                        select k).ToList();
            return stores;

        }



        public LaptopModels searchName(SearchIndex search)
        {
            return (from k in _db.LaptopModels 
                    where k.Name == search.Name 
                    select k).FirstOrDefault();
        }


        //Quantity for Laptop
        public int? calculateQuantity(SearchIndex search)
        {
            return (from k in _db.LaptopModels 
                    where k.Name == search.Name 
                    select (int?)k.Quantity).Sum();
        }

        //Quantity for Store
        public int? calculateStoreQuantity(SearchIndex search)
        {
            return (from k in _db.StoreModels 
                    where k.Name == search.Name 
                    select (int?)k.QoP).Sum();
        }

        //Quantitiy for Location
        public int? calculateLocationQuantity(SearchIndex search)
        {
            return (from k in _db.StoreModels 
                    where k.Location == search.Name 
                    select (int?)k.QoP).Sum();
        }

        //Quantity for ZipCode
        public int? calculateZipCodeQuantity(int? test)
        {
            return (from k in _db.StoreModels 
                    where k.ZipCode == test 
                    select (int?)k.QoP).Sum();
        }

        //Quantity for Transfer
        public int? calculateTransferQuantity(SearchIndex search)
        {
            return (from k in _db.TransferModels 
                    where k.LaptopName == search.Name 
                    select (int?)k.LaptopQuantity).Sum();
        }

        //Quantity for Transfer Store Quantity
        public int? calculateTransferStoreQuantity(int store)
        {
            return (from t in _db.TransferModels 
                    where t.StoreID == store 
                    select (int?)t.LaptopQuantity).Sum();
        }

        public LaptopModels searchManufacturer(SearchIndex search)
        {
            return (from k in _db.LaptopModels 
                    where k.Manufacturer == search.Name 
                    select k).FirstOrDefault();
        }

        public LaptopModels searchOS(SearchIndex search)
        {
            return (from k in _db.LaptopModels 
                    where k.OS == search.Name 
                    select k).FirstOrDefault();
        }

        public StoreModels searchStores(SearchIndex search)
        {
            return (from k in _db.StoreModels 
                    where k.Name == search.Name 
                    select k).FirstOrDefault();
        }

        public StoreModels searchZipCode(int? test)
        {
            return (from k in _db.StoreModels 
                    where k.ZipCode == test 
                    select k).FirstOrDefault();
        }

        public TransferModels searchStore(int store)
        {
            return (from t in _db.TransferModels 
                    where t.StoreID == store 
                    select t).FirstOrDefault();
        }

        public List<StoreModels> storeList(SearchIndex search)
        {
            return (from k in _db.StoreModels 
                    where k.Name == search.Name 
                    select k).ToList();
        }

        public List<StoreModels> storeListByZipCode(int? test)
        {
            return (from k in _db.StoreModels 
                    where k.ZipCode == test 
                    select k).ToList();
        }


        public StoreModels searchLocation(SearchIndex search)
        {
            return (from k in _db.StoreModels 
                    where k.Location == search.Name 
                    select k).FirstOrDefault();
        }

        public List<TransferModels> searchTransferByLaptopName(SearchIndex search)
        {
            return (from k in _db.TransferModels 
                    where k.LaptopName == search.Name 
                    select k).ToList();
        }


        public int storeID(SearchIndex search)
        {
            return (from s in _db.StoreModels
                    where s.Name == search.Name
                    select s.ID).SingleOrDefault();

        }

        public List<TransferModels> transfer(int store)
        {
            return (from t in _db.TransferModels
                    where t.StoreID == store
                    select t).ToList();
        }

        //Create new log
        public LogModels log3()
        {
            LogModels log = new LogModels
            {
                Type = "3",
                Description = "There was new search in Laptop section for " + search.Name + ".",
                Date = DateTime.Now
            };

            _db.LogModels.Add(log);
            _db.SaveChanges();
            return log;
        }


        //Create new log
        public LogModels log4()
        {
            LogModels log = new LogModels
            {
                Type = "4",
                Description = "There was new search in Transfer section for " + search.Name + ".",
                Date = DateTime.Now
            };

            _db.LogModels.Add(log);
            _db.SaveChanges();
            return log;
        }



        // GET: Search
        //Search - Laptop
        //Search - Store
        //Search - Transfer

        //Example 1. search for Notebook Acer Aspire 1 in Laptop section
        //Example 2. search for SD Store Zadar in Store section
        //Example 3. search for Notebook HP 250-G7 in Transfers
        public ActionResult Index()
        {
            

            try
            {
                return View();
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

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Result(FormCollection form)
        {
          

            //Search for Laptop


            if (form["name"] != null)
            {

                search.Name = form["name"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                ViewBag.searchname = searchName(search);
                ViewBag.quantity = calculateQuantity(search);
                findSearch(search);

                if (ViewBag.searchname == null)
                {
                    //Create new log

                    log4();
                    return View("ResultNotExists");
                }

                else
                {


                    //Create new log
                    
                    log3();

                    return View(findSearch(search));
                }
            }


          
            return View();
        }


        public ActionResult SearchByManufacturer(FormCollection form)
        {
   

            if (form["manufacturer"] != null)
            {


                search.Name = form["manufacturer"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                ViewBag.searchname = searchManufacturer(search);
                ViewBag.quantity = calculateQuantity(search);
                findSearch(search);


                if (ViewBag.searchname == null)
                {
                    //Create new log

                    log4();
                    return View("ResultNotExists");
                }

                else
                {


                    //Create new log
 
                    log3();

                    return View(findSearch(search));
                }
            }

            return View();
        }


        public ActionResult SearchByOS(FormCollection form)
        {
           

            if (form["os"] != null)
            {

          
                search.Name = form["os"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                ViewBag.searchname = searchOS(search);
                ViewBag.quantity = calculateQuantity(search);
                findSearchOS(search);

                //log for Search if not exists

                if (ViewBag.searchname == null)
                {
                    //Create new log

                    log4();
                    return View("ResultNotExists");
                }

                else
                {
                    

                    //Create new log
                 
                    log3();

                    return View(findSearchOS(search));
                }
            }

            return View();
        }



        public ActionResult SearchStore(FormCollection form)
        {
                     

           if (form["storeName"] != null){

                search.Name = form["storeName"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                ViewBag.searchName = searchStores(search);
                ViewBag.quantity = calculateStoreQuantity(search);

                if (ViewBag.searchName == null)
                {
                    //Create new log
                    log4();
                    _db.SaveChanges();
                    return View("ResultNotExists");
                }
                else
                {

                    //Create new log
                    log3();
                    return View("ResultStore", storeList(search));
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
                ViewBag.searchName = searchLocation(search);
                ViewBag.quantity = calculateLocationQuantity(search);
               
                if (ViewBag.searchName == null)
                {
                    //Create new log

                    log4();
                    return View("ResultNotExists");
                }
                else
                {

                    //Create new log

                    log3();
                    
                    return View("ResultStore", findSearchLocation(search));
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
                ViewBag.searchName = searchZipCode(test);
                ViewBag.quantity = calculateZipCodeQuantity(test);

                if (ViewBag.searchName == null)
                {
                    //Create new log
                    log4();
                    return View("ResultNotExists");
                }
                else
                {

                    //Create new log
                    log3();
                    return View("ResultStore", storeListByZipCode(test));
                }
            }

            return View();
        }

        public ActionResult SearchTransfer(FormCollection form)
        {
         

            //Search for Store

            if (form["laptopName"] != null)
            {
                search.Name = form["laptopName"];
                ViewBag.Name = search.Name;
                TempData["searchName"] = ViewBag.Name;
                ViewBag.searchname = searchTransferByLaptopName(search);
                ViewBag.quantity = calculateTransferQuantity(search);
                if (ViewBag.searchname == null && ViewBag.quantity == null)
                {
                    //Create new log
                    log4();
                    return View("ResultNotExists");
                }
                else
                {

                    //Add store object to list

                    log3();
                    return View("ResultTransfer", searchTransferByLaptopName(search));
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

                int store = storeID(search);

                ViewBag.searchname = searchStore(store);
              
                ViewBag.quantity = calculateTransferStoreQuantity(store);
                   

                if (ViewBag.searchname == null && ViewBag.quantity == null)
                {
                    //Create new log
                    log4();
                    return View("ResultNotExists");
                }
                else
                {

                    //Create new log
                    log3();
                    return View("ResultTransfer", transfer(store));
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