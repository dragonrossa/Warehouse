using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.OrderBy
{
    public class OrderByUserController : Controller
    {
         UserModels  user = new UserModels();

        //User - Index - Name, LastName, Username

        public ActionResult AscName()
        {

            return View("~/Views/Admin/Index.cshtml", new UserModels { users = user.AscendingByName });

        }

        public ActionResult DescName()
        {
            return View("~/Views/Admin/Index.cshtml", new UserModels { users = user.DescendingByName });

        }

        public ActionResult AscLastName()
        {

            return View("~/Views/Admin/Index.cshtml", new UserModels { users = user.AscendingByLastName });

        }

        public ActionResult DescLastName()
        {
            return View("~/Views/Admin/Index.cshtml", new UserModels { users = user.DescendingByLastName });

        }

        public ActionResult AscUsername()
        {

            return View("~/Views/Admin/Index.cshtml", new UserModels { users = user.AscendingByUserName });

        }

        public ActionResult DescUsername()
        {
            return View("~/Views/Admin/Index.cshtml", new UserModels { users = user.DescendingByUserName });

        }
    }
}