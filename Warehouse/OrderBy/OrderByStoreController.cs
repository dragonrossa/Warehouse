using PagedList;
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

            return View("~/Views/Store/Index.cshtml",  store.AscendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));

        }

        public ActionResult DescName()
        {
            return View("~/Views/Store/Index.cshtml",  store.DescendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));

        }

        public ActionResult AscLocation()
        {
            return View("~/Views/Store/Index.cshtml",  store.AscendingByLocation.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescLocation()
        {
            return View("~/Views/Store/Index.cshtml",  store.DescendingByLocation.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


        public ActionResult AscQuantity()
        {
            return View("~/Views/Store/Index.cshtml", store.AscendingByQuantityOfProducts.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescQuantity()
        {
            return View("~/Views/Store/Index.cshtml", store.DescendingByQuantityOfProducts.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


        //next

        //Store - List - Name, Location, Zip code

        public ActionResult AscNameList()
        {

            return View("~/Views/Store/List.cshtml",  store.AscendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescNameList()
        {
            return View("~/Views/Store/List.cshtml", store.DescendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


        public ActionResult AscLocationList()
        {
            return View("~/Views/Store/List.cshtml", store.AscendingByLocation.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescLocationList()
        {
            return View("~/Views/Store/List.cshtml", store.DescendingByZipcode.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult AscZipcodeList()
        {
            return View("~/Views/Store/List.cshtml",  store.AscendingByZipcode.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescZipcodeList()
        {
            return View("~/Views/Store/List.cshtml",  store.DescendingByZipcode.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }



        //Store - Edit - Name, Location, Zip code

        public ActionResult AscNameEdit()
        {

            return View("~/Views/Store/EditList.cshtml",  store.AscendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescNameEdit()
        {
            return View("~/Views/Store/EditList.cshtml",  store.DescendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


        public ActionResult AscLocationEdit()
        {
            return View("~/Views/Store/EditList.cshtml",  store.AscendingByLocation.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescLocationEdit()
        {
            return View("~/Views/Store/EditList.cshtml",  store.DescendingByLocation.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult AscZipcodeEdit()
        {
            return View("~/Views/Store/EditList.cshtml",  store.AscendingByZipcode.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescZipcodeEdit()
        {
            return View("~/Views/Store/EditList.cshtml",  store.DescendingByZipcode.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        //Store - Delete - Name, Location, Zip code

        public ActionResult AscNameDelete()
        {

            return View("~/Views/Store/DeleteList.cshtml",  store.AscendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescNameDelete()
        {
            return View("~/Views/Store/DeleteList.cshtml",  store.DescendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


        public ActionResult AscLocationDelete()
        {
            return View("~/Views/Store/DeleteList.cshtml",  store.AscendingByLocation.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescLocationDelete()
        {
            return View("~/Views/Store/DeleteList.cshtml",  store.DescendingByLocation.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult AscZipcodeDelete()
        {
            return View("~/Views/Store/DeleteList.cshtml",  store.AscendingByZipcode.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescZipcodeDelete()
        {
            return View("~/Views/Store/DeleteList.cshtml",  store.DescendingByZipcode.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }
    }
}