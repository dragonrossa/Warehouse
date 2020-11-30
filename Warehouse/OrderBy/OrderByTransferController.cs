using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Helpers;

namespace Warehouse.OrderBy
{
    public class OrderByTransferController : Controller
    {
       TransferResult transfer= new TransferResult();

        //Transfer - Index - Name, Quantity of products, Location

        public ActionResult AscName()
        {

            return View("~/Views/Transfer/Index.cshtml", new TransferResult { result = transfer.AscendingByName });

        }

        public ActionResult DescName()
        {
            return View("~/Views/Transfer/Index.cshtml", new TransferResult { result = transfer.DescendingByName });

        }

        public ActionResult AscQuantity()
        {
            return View("~/Views/Transfer/Index.cshtml", new TransferResult { result = transfer.AscendingByQuantity });
        }

        public ActionResult DescQuantity()
        {
            return View("~/Views/Transfer/Index.cshtml", new TransferResult { result = transfer.DescendingByQuantity });
        }

        public ActionResult AscLocation()
        {
            return View("~/Views/Transfer/Index.cshtml", new TransferResult { result = transfer.AscendingByPlace });
        }

        public ActionResult DescLocation()
        {
            return View("~/Views/Transfer/Index.cshtml", new TransferResult { result = transfer.DescendingByPlace });
        }


    }
}