using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class UserRightsController : Controller
    {
      
        //Get User Rights Repository
        UserRightsRepository userRightsRepository = new UserRightsRepository();

        // GET: UserRights
        public ActionResult Header()
        {
           
            // Your user information in HeaderModel
            return PartialView("Header", userRightsRepository.admin(User.Identity.GetUserName()));
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}