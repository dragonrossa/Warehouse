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
        public ApplicationDbContext _db = new ApplicationDbContext();
        // GET: UserRights
        [HttpGet]
        public ActionResult Header()
        {
            AdminModels admin = new AdminModels();

            var user = User.Identity.GetUserName();
            admin = (from a in _db.AdminModels where a.Username == user select a).FirstOrDefault();

            // Your user information in HeaderModel
            return PartialView("Header", admin);
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}