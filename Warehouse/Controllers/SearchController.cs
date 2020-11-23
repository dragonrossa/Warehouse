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
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class SearchController : Controller
    {

        //Get Search Repository
        SearchRepository searchRepository = new SearchRepository();

        //Create class object
        SearchIndex search = new SearchIndex();

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
                ViewBag.searchname = searchRepository.searchName(search);
                ViewBag.quantity = searchRepository.calculateQuantity(search);
                searchRepository.findSearch(search);

                if (ViewBag.searchname == null)
                {
                    //Create new log

                    searchRepository.log4(search);
                    return View("ResultNotExists");
                }

                else
                {


                    //Create new log

                    searchRepository.log3(search);

                    return View(searchRepository.findSearch(search));
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
                ViewBag.searchname = searchRepository.searchManufacturer(search);
                ViewBag.quantity = searchRepository.calculateQuantity(search);
                searchRepository.findSearch(search);


                if (ViewBag.searchname == null)
                {
                    //Create new log

                    searchRepository.log4(search);
                    return View("ResultNotExists");
                }

                else
                {


                    //Create new log

                    searchRepository.log3(search);

                    return View(searchRepository.findSearch(search));
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
                ViewBag.searchname = searchRepository.searchOS(search);
                ViewBag.quantity = searchRepository.calculateQuantity(search);
                searchRepository.findSearchOS(search);

                //log for Search if not exists

                if (ViewBag.searchname == null)
                {
                    //Create new log

                    searchRepository.log4(search);
                    return View("ResultNotExists");
                }

                else
                {


                    //Create new log

                    searchRepository.log3(search);

                    return View(searchRepository.findSearchOS(search));
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
                ViewBag.searchName = searchRepository.searchStores(search);
                ViewBag.quantity = searchRepository.calculateStoreQuantity(search);

                if (ViewBag.searchName == null)
                {
                    //Create new log
                    searchRepository.log4(search);
                    searchRepository.SaveData();
                    return View("ResultNotExists");
                }
                else
                {

                    //Create new log
                    searchRepository.log3(search);
                    return View("ResultStore", searchRepository.storeList(search));
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
                ViewBag.searchName = searchRepository.searchLocation(search);
                ViewBag.quantity = searchRepository.calculateLocationQuantity(search);
               
                if (ViewBag.searchName == null)
                {
                    //Create new log

                    searchRepository.log4(search);
                    return View("ResultNotExists");
                }
                else
                {

                    //Create new log

                    searchRepository.log3(search);
                    
                    return View("ResultStore", searchRepository.findSearchLocation(search));
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
                ViewBag.searchName = searchRepository.searchZipCode(test);
                ViewBag.quantity = searchRepository.calculateZipCodeQuantity(test);

                if (ViewBag.searchName == null)
                {
                    //Create new log
                    searchRepository.log4(search);
                    return View("ResultNotExists");
                }
                else
                {

                    //Create new log
                    searchRepository.log3(search);
                    return View("ResultStore", searchRepository.storeListByZipCode(test));
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
                ViewBag.searchname = searchRepository.searchTransferByLaptopName(search);
                ViewBag.quantity = searchRepository.calculateTransferQuantity(search);
                if (ViewBag.searchname == null && ViewBag.quantity == null)
                {
                    //Create new log
                    searchRepository.log4(search);
                    return View("ResultNotExists");
                }
                else
                {

                    //Add store object to list

                    searchRepository.log3(search);
                    return View("ResultTransfer", searchRepository.searchTransferByLaptopName(search));
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

                int store = searchRepository.storeID(search);

                ViewBag.searchname = searchRepository.searchStore(store);
              
                ViewBag.quantity = searchRepository.calculateTransferStoreQuantity(store);
                   

                if (ViewBag.searchname == null && ViewBag.quantity == null)
                {
                    //Create new log
                    searchRepository.log4(search);
                    return View("ResultNotExists");
                }
                else
                {

                    //Create new log
                    searchRepository.log3(search);
                    return View("ResultTransfer", searchRepository.transfer(store));
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