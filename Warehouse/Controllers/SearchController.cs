using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Warehouse.Controllers
{
    public class SearchController : Controller
    {

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
    }
}