using System;
using System.Collections.Generic;
using System.Linq;
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
           
            search.Name = form["name"];

            ViewBag.Name = search.Name;
            TempData["searchName"] = ViewBag.Name;
            var searchName = (from k in _db.LaptopModels where k.Name==search.Name select k).FirstOrDefault();

            if (searchName == null)
            {
                return View("ResultNotExists");
            }

            else
            {
                //Create Laptop object
                search.LaptopName = searchName.Name;
                search.Quantity = searchName.Quantity;
                search.FullPrice = searchName.FullPrice;

                //Add object to list

                index.Add(search);
                return View(index);
            }
        }

        public ActionResult ResultNotExists()
        {
            
            return View();
        }
    }
}