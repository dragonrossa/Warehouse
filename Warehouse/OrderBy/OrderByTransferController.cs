using PagedList;
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

            return View("~/Views/Transfer/Index.cshtml", transfer.AscendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));

        }

        public ActionResult DescName()
        {
            return View("~/Views/Transfer/Index.cshtml", transfer.DescendingByName.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));

        }

        public ActionResult AscQuantity()
        {
            return View("~/Views/Transfer/Index.cshtml", transfer.AscendingByQuantity.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescQuantity()
        {
            return View("~/Views/Transfer/Index.cshtml", transfer.DescendingByQuantity.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult AscLocation()
        {
            return View("~/Views/Transfer/Index.cshtml", transfer.AscendingByPlace.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }

        public ActionResult DescLocation()
        {
            return View("~/Views/Transfer/Index.cshtml", transfer.DescendingByPlace.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));
        }


    }
}