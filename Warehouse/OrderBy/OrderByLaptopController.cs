using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.OrderBy
{
    public class OrderByLaptopController : Controller
    {
        LaptopModels laptop = new LaptopModels();

        //Sort for Index
        //We need - Name, Quantity, Price, Full Price

        public ActionResult AscName()
        {

            return View("~/Views/Laptop/Index.cshtml", laptop.AscendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));

        }

        public ActionResult DescName()
        {
            return View("~/Views/Laptop/Index.cshtml", laptop.DescendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));

        }


        public ActionResult AscQuantity()
        {
            return View("~/Views/Laptop/Index.cshtml", laptop.AscendingByQuantity.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescQuantity()
        {
            return View("~/Views/Laptop/Index.cshtml",  laptop.DescendingByQuantity.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult AscPrice()
        {
            return View("~/Views/Laptop/Index.cshtml",  laptop.AscendingByPrice.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescPrice()
        {
            return View("~/Views/Laptop/Index.cshtml", laptop.DescendingByPrice.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


        public ActionResult AscFullPrice()
        {
            return View("~/Views/Laptop/Index.cshtml", laptop.AscendingByFullPrice.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescFullPrice()
        {
            return View("~/Views/Laptop/Index.cshtml",  laptop.DescendingByFullPrice.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


        //Sort for List
        // We need - Name, Details, Quantity, OS, Price

        public ActionResult AscNameList()
        {

            return View("~/Views/Laptop/List.cshtml", laptop.AscendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescNameList()
        {
            return View("~/Views/Laptop/List.cshtml", laptop.DescendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


        public ActionResult AscQuantityList()
        {
            return View("~/Views/Laptop/List.cshtml",  laptop.AscendingByQuantity.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescQuantityList()
        {
            return View("~/Views/Laptop/List.cshtml",  laptop.DescendingByQuantity.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult AscPriceList()
        {
            return View("~/Views/Laptop/List.cshtml",  laptop.AscendingByPrice.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescPriceList()
        {
            return View("~/Views/Laptop/List.cshtml",  laptop.DescendingByPrice.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


        public ActionResult AscOSList()
        {
            return View("~/Views/Laptop/List.cshtml", laptop.AscendingByOS.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescOSList()
        {
            return View("~/Views/Laptop/List.cshtml",  laptop.DescendingByOS.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        //Sort for EditList
        // We need - Name, Quantity, Price

        public ActionResult AscNameEditList()
        {

            return View("~/Views/Laptop/EditList.cshtml",  laptop.AscendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescNameEditList()
        {
            return View("~/Views/Laptop/EditList.cshtml",  laptop.DescendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


        public ActionResult AscQuantityEditList()
        {
            return View("~/Views/Laptop/EditList.cshtml",  laptop.AscendingByQuantity.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescQuantityEditList()
        {
            return View("~/Views/Laptop/EditList.cshtml",  laptop.DescendingByQuantity.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult AscPriceEditList()
        {
            return View("~/Views/Laptop/EditList.cshtml",  laptop.AscendingByPrice.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescPriceEditList()
        {
            return View("~/Views/Laptop/EditList.cshtml", laptop.DescendingByPrice.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


        //Sort for Delete
        // We need - Name, Quantity, Price

        public ActionResult AscNameDelete()
        {

            return View("~/Views/Laptop/DeleteList.cshtml",  laptop.AscendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescNameDelete()
        {
            return View("~/Views/Laptop/DeleteList.cshtml",  laptop.DescendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


        public ActionResult AscQuantityDelete()
        {
            return View("~/Views/Laptop/DeleteList.cshtml",  laptop.AscendingByQuantity.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescQuantityDelete()
        {
            return View("~/Views/Laptop/DeleteList.cshtml",  laptop.DescendingByQuantity.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult AscPriceDelete()
        {
            return View("~/Views/Laptop/DeleteList.cshtml",  laptop.AscendingByPrice.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescPriceDelete()
        {
            return View("~/Views/Laptop/DeleteList.cshtml",  laptop.DescendingByPrice.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }
    }
}