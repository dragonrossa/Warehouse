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

            return View("~/Views/TaskList/MyList.cshtml", new TaskListModels { task = taskList.AscendingByID });

        }

        public ActionResult DescID()
        {
            return View("~/Views/TaskList/MyList.cshtml", new TaskListModels { task = taskList.DescendingByID });

        }

        // TaskList / MyList - ID + status

        public ActionResult AscIDList()
        {

            return View("~/Views/TaskList/List.cshtml", new TaskListModels { task = taskList.AscendingByID });

        }

        public ActionResult DescIDList()
        {
            return View("~/Views/TaskList/List.cshtml", new TaskListModels { task = taskList.DescendingByID });

        }

        public ActionResult DescStatusList()
        {
            return View("~/Views/TaskList/List.cshtml", new TaskListModels { task = taskList.AscendingByStatus });

        }
        public ActionResult AscStatusList()
        {

            return View("~/Views/TaskList/List.cshtml", new TaskListModels { task = taskList.DescendingByStatus });

        }
    }
}