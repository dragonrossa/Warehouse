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

           return View("~/Views/Laptop/Index.cshtml", new LaptopModels { laptop = laptop.AscendingByName });

        }

        public ActionResult DescName()
        {
            return View("~/Views/Laptop/Index.cshtml", new LaptopModels { laptop = laptop.DescendingByName });

        }


        public ActionResult AscQuantity()
        {
            return View("~/Views/Laptop/Index.cshtml", new LaptopModels { laptop = laptop.AscendingByQuantity });
        }

        public ActionResult DescQuantity()
        {
            return View("~/Views/Laptop/Index.cshtml", new LaptopModels { laptop = laptop.DescendingByQuantity });
        }

        public ActionResult AscPrice()
        {
            return View("~/Views/Laptop/Index.cshtml", new LaptopModels { laptop = laptop.AscendingByPrice });
        }

        public ActionResult DescPrice()
        {
            return View("~/Views/Laptop/Index.cshtml", new LaptopModels { laptop = laptop.DescendingByPrice });
        }


        public ActionResult AscFullPrice()
        {
            return View("~/Views/Laptop/Index.cshtml", new LaptopModels { laptop = laptop.AscendingByFullPrice });
        }

        public ActionResult DescFullPrice()
        {
            return View("~/Views/Laptop/Index.cshtml", new LaptopModels { laptop = laptop.DescendingByFullPrice });
        }


        //Sort for List
        // We need - Name, Details, Quantity, OS, Price

        public ActionResult AscNameList()
        {

            return View("~/Views/Laptop/List.cshtml", new LaptopModels { laptop = laptop.AscendingByName });
        }

        public ActionResult DescNameList()
        {
            return View("~/Views/Laptop/List.cshtml", new LaptopModels { laptop = laptop.DescendingByName });
        }


        public ActionResult AscQuantityList()
        {
            return View("~/Views/Laptop/List.cshtml", new LaptopModels { laptop = laptop.AscendingByQuantity });
        }

        public ActionResult DescQuantityList()
        {
            return View("~/Views/Laptop/List.cshtml", new LaptopModels { laptop = laptop.DescendingByQuantity });
        }

        public ActionResult AscPriceList()
        {
            return View("~/Views/Laptop/List.cshtml", new LaptopModels { laptop = laptop.AscendingByPrice });
        }

        public ActionResult DescPriceList()
        {
            return View("~/Views/Laptop/List.cshtml", new LaptopModels { laptop = laptop.DescendingByPrice });
        }


        public ActionResult AscOSList()
        {
            return View("~/Views/Laptop/List.cshtml", new LaptopModels { laptop = laptop.AscendingByOS });
        }

        public ActionResult DescOSList()
        {
            return View("~/Views/Laptop/List.cshtml", new LaptopModels { laptop = laptop.DescendingByOS });
        }

        //Sort for EditList
        // We need - Name, Quantity, Price

        public ActionResult AscNameEditList()
        {

            return View("~/Views/Laptop/EditList.cshtml", new LaptopModels { laptop = laptop.AscendingByName });
        }

        public ActionResult DescNameEditList()
        {
            return View("~/Views/Laptop/EditList.cshtml", new LaptopModels { laptop = laptop.DescendingByName });
        }


        public ActionResult AscQuantityEditList()
        {
            return View("~/Views/Laptop/EditList.cshtml", new LaptopModels { laptop = laptop.AscendingByQuantity });
        }

        public ActionResult DescQuantityEditList()
        {
            return View("~/Views/Laptop/EditList.cshtml", new LaptopModels { laptop = laptop.DescendingByQuantity });
        }

        public ActionResult AscPriceEditList()
        {
            return View("~/Views/Laptop/EditList.cshtml", new LaptopModels { laptop = laptop.AscendingByPrice });
        }

        public ActionResult DescPriceEditList()
        {
            return View("~/Views/Laptop/EditList.cshtml", new LaptopModels { laptop = laptop.DescendingByPrice });
        }


        //Sort for Delete
        // We need - Name, Quantity, Price

        public ActionResult AscNameDelete()
        {

            return View("~/Views/Laptop/DeleteList.cshtml", new LaptopModels { laptop = laptop.AscendingByName });
        }

        public ActionResult DescNameDelete()
        {
            return View("~/Views/Laptop/DeleteList.cshtml", new LaptopModels { laptop = laptop.DescendingByName });
        }


        public ActionResult AscQuantityDelete()
        {
            return View("~/Views/Laptop/DeleteList.cshtml", new LaptopModels { laptop = laptop.AscendingByQuantity });
        }

        public ActionResult DescQuantityDelete()
        {
            return View("~/Views/Laptop/DeleteList.cshtml", new LaptopModels { laptop = laptop.DescendingByQuantity });
        }

        public ActionResult AscPriceDelete()
        {
            return View("~/Views/Laptop/DeleteList.cshtml", new LaptopModels { laptop = laptop.AscendingByPrice });
        }

        public ActionResult DescPriceDelete()
        {
            return View("~/Views/Laptop/DeleteList.cshtml", new LaptopModels { laptop = laptop.DescendingByPrice });
        }
    }
}