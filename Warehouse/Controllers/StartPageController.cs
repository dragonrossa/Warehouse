using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class StartPageController : Controller
    {
        // GET: StartPage
        private ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var user = (from u in _db.UserModels where u.UserName == username select u).FirstOrDefault();
            ViewBag.user = user.Name;
            return View();
        }
    }
}