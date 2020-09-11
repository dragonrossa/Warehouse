using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Warehouse.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: User
        public ActionResult Index()
        {
            var user = User.Identity.GetUserName();
            UserModels userModels = (from k in _db.UserModels where k.Mail==user select k).First();
            ViewBag.user = user;
            return View(userModels);
        }

        [HttpPost]
        public ActionResult Index(UserModels userModels)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(userModels).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index","Manage");
            }
            return View(userModels);
            
        }
    }
}