using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin

        //list of users + list of roles + check button for roles
        public ActionResult Index()
        {
            try
            {
                List<UserModels> users = (from u in _db.UserModels
                                          select u).ToList();
                return View(users);
            }
            catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {

            }
            return View();
        }

        public ActionResult ChangeRole(int id)
        {
            int UserID = id;

            TempData["UserID"] = UserID;

            var user = (from u in _db.UserModels
                        where u.ID==UserID
                        select u).FirstOrDefault();

            ViewBag.user = user.Name + " " + user.LastName;
            ViewBag.username = user.UserName;
            ViewBag.currentRole = (from r in _db.RolesModels 
                                   join a in _db.AdminModels
                                   on r.ID equals a.RoleID
                                   where a.Username == user.UserName
                                   select r.Role).SingleOrDefault();

            TempData["username"] = ViewBag.username;

            ViewData["Roles"] = _db.RolesModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Role,
                Value = u.ID.ToString()
            }).ToList();

            return View(user);
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult ChangeRole(FormCollection form)
        {
          
            AdminModels admin = new AdminModels();

            if (ModelState.IsValid)
            {
                string roleID = form["Roles"]; //1 for Chief
                admin.RoleID = Convert.ToInt32(roleID);
                admin.Username = TempData["username"].ToString();

                //if username is already in table update
                //if username is not already in table create record

                var username = (from u in _db.AdminModels  where u.Username == admin.Username select u.Username).FirstOrDefault();
                var user = (from u in _db.AdminModels where u.Username == admin.Username select u).FirstOrDefault();

                if (admin.Username == username)
                {
                   // admin.RoleID = Convert.ToInt32(roleID);
                    user.RoleID = Convert.ToInt32(roleID);
                    _db.SaveChanges();
                }
                else
                { 
                    _db.AdminModels.Add(admin);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", new { });
                } }

            return RedirectToAction("Index", "Admin", new { });

        }
    }
}