using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.OrderBy
{
    public class OrderByTaskController : Controller
    {
        TaskListModels taskList = new TaskListModels();

        // TaskList / MyList - orderbyID

        public ActionResult AscID()
        {

            return View("~/Views/TaskList/MyList.cshtml", taskList.AscendingByID.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));

        }

        public ActionResult DescID()
        {
            return View("~/Views/TaskList/MyList.cshtml", taskList.DescendingByID.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));

        }

        // TaskList / MyList - ID + status

        public ActionResult AscIDList()
        {

            return View("~/Views/TaskList/List.cshtml", taskList.AscendingByID.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));

        }

        public ActionResult DescIDList()
        {
            return View("~/Views/TaskList/List.cshtml", taskList.DescendingByID.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));

        }

        public ActionResult DescStatusList()
        {
            return View("~/Views/TaskList/List.cshtml", taskList.AscendingByStatus.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));

        }
        public ActionResult AscStatusList()
        {

            return View("~/Views/TaskList/List.cshtml", taskList.DescendingByStatus.ToPagedList(Convert.ToInt32(Session["pageNumber"]), Convert.ToInt32(Session["pageSize"])));

        }
    }
}