using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.OrderBy
{
    public class OrderByStoreController : Controller
    {

        StoreModels store = new StoreModels();

        //Store - Index - Name, Location, Quantity of products

        public ActionResult AscName()
        {

            return View("~/Views/Store/Index.cshtml", new StoreModels { store = store.AscendingByName });

        }

        public ActionResult DescName()
        {
            return View("~/Views/Store/Index.cshtml", new StoreModels { store = store.DescendingByName });

        }

        public ActionResult AscLocation()
        {
            return View("~/Views/Store/Index.cshtml", new StoreModels { store = store.AscendingByLocation });
        }

        public ActionResult DescLocation()
        {
            return View("~/Views/Store/Index.cshtml", new StoreModels { store = store.DescendingByLocation });
        }


        public ActionResult AscQuantity()
        {
            return View("~/Views/Store/Index.cshtml", new StoreModels { store = store.AscendingByQuantityOfProducts });
        }

        public ActionResult DescQuantity()
        {
            return View("~/Views/Store/Index.cshtml", new StoreModels { store = store.DescendingByQuantityOfProducts });
        }


        //next

        //Store - List - Name, Location, Zip code

        public ActionResult AscNameList()
        {

            return View("~/Views/Store/List.cshtml", new StoreModels { store = store.AscendingByName });
        }

        public ActionResult DescNameList()
        {
            return View("~/Views/Store/List.cshtml", new StoreModels { store = store.DescendingByName });
        }


        public ActionResult AscLocationList()
        {
            return View("~/Views/Store/List.cshtml", new StoreModels { store = store.AscendingByLocation });
        }

        public ActionResult DescLocationList()
        {
            return View("~/Views/Store/List.cshtml", new StoreModels { store = store.DescendingByZipcode });
        }

        public ActionResult AscZipcodeList()
        {
            return View("~/Views/Store/List.cshtml", new StoreModels { store = store.AscendingByZipcode });
        }

        public ActionResult DescZipcodeList()
        {
            return View("~/Views/Store/List.cshtml", new StoreModels { store = store.DescendingByZipcode });
        }



        //Store - Edit - Name, Location, Zip code

        public ActionResult AscNameEdit()
        {

            return View("~/Views/Store/EditList.cshtml", new StoreModels { store = store.AscendingByName });
        }

        public ActionResult DescNameEdit()
        {
            return View("~/Views/Store/EditList.cshtml", new StoreModels { store = store.DescendingByName });
        }


        public ActionResult AscLocationEdit()
        {
            return View("~/Views/Store/EditList.cshtml", new StoreModels { store = store.AscendingByLocation });
        }

        public ActionResult DescLocationEdit()
        {
            return View("~/Views/Store/EditList.cshtml", new StoreModels { store = store.DescendingByLocation });
        }

        public ActionResult AscZipcodeEdit()
        {
            return View("~/Views/Store/EditList.cshtml", new StoreModels { store = store.AscendingByZipcode });
        }

        public ActionResult DescZipcodeEdit()
        {
            return View("~/Views/Store/EditList.cshtml", new StoreModels { store = store.DescendingByZipcode });
        }

        //Store - Delete - Name, Location, Zip code

        public ActionResult AscNameDelete()
        {

            return View("~/Views/Store/DeleteList.cshtml", new StoreModels { store = store.AscendingByName });
        }

        public ActionResult DescNameDelete()
        {
            return View("~/Views/Store/DeleteList.cshtml", new StoreModels { store = store.DescendingByName });
        }


        public ActionResult AscLocationDelete()
        {
            return View("~/Views/Store/DeleteList.cshtml", new StoreModels { store = store.AscendingByLocation });
        }

        public ActionResult DescLocationDelete()
        {
            return View("~/Views/Store/DeleteList.cshtml", new StoreModels { store = store.DescendingByLocation });
        }

        public ActionResult AscZipcodeDelete()
        {
            return View("~/Views/Store/DeleteList.cshtml", new StoreModels { store = store.AscendingByZipcode });
        }

        public ActionResult DescZipcodeDelete()
        {
            return View("~/Views/Store/DeleteList.cshtml", new StoreModels { store = store.DescendingByZipcode });
        }
    }
}