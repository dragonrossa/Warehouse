﻿using Microsoft.AspNet.Identity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            var user = User.Identity.GetUserName();

            bool access = (from a in _db.AdminModels where a.Username == user select a.Access).FirstOrDefault();

            bool fal = false;

            if (access == fal)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return RedirectToAction("Index","Laptop");
            }
            else
            {

                try
                {
                    List<UserModels> users = (from u in _db.UserModels
                                              select u).ToList();
                    return View(users);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                finally
                {

                }
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

            TempData["currentRole"] = ViewBag.currentRole;

            TempData["username"] = ViewBag.username;

            ViewData["Roles"] = _db.RolesModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Role,
                Value = u.ID.ToString()
            }).ToList();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                  
                    user.RoleID = Convert.ToInt32(roleID);
                    _db.SaveChanges();

                   //Create new log

                LogModels log = new LogModels
                {
                    Type = "6",
                    Description = "New change was made for user " + user.Username + " on date " + DateTime.Now + " for role " + TempData["currentRole"] + ".",
                    Date = DateTime.Now
                };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                }
                else
                { 
                    _db.AdminModels.Add(admin);
                    _db.SaveChanges();

                    
                    LogModels log = new LogModels
                    {
                        Type = "6",
                        Description = "Change was made for user " + user.Username + " on date " + DateTime.Now + " for role " + admin.RoleID + ".",
                        Date = DateTime.Now
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", new { });
                } }

            return RedirectToAction("Index", "Admin", new { });

        }

        public ActionResult ChangeDetails(int id)
        {
            
            TempData["UserID"] = id;


            if (ModelState.IsValid)
            {

                UserModels user = _db.UserModels.Find(id);

                return View(user);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeDetails(UserModels user)
        {
            if (ModelState.IsValid)
            {

                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", "Admin", user);

            }
            return View();
        }

        public ActionResult Access(int id)
        {
            TempData["UserID"] = id;


            var user = (from u in _db.UserModels where u.ID==id select u).FirstOrDefault();


            if (ModelState.IsValid)
            {

                AdminModels admin = (from a in _db.AdminModels where a.Username == user.UserName select a).FirstOrDefault();
                TempData["AdminID"] = admin.ID;

                return View(admin);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Access(AdminModels admin, FormCollection form, int id)
        {
            string access = form["access"];

            int adminID = id;

            var adminUser = (from a in _db.AdminModels where a.ID == adminID select a).FirstOrDefault();

            if (ModelState.IsValid)
            {

                if (access == "true,false")
                {

                    access = "true";
                    adminUser.Access = Convert.ToBoolean(access);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", admin);
                }
                else
                {
                    access = "false";
                    adminUser.Access = Convert.ToBoolean(access);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", admin);

                }
  
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LaptopAccess(AdminModels admin, FormCollection form, int id)
        {
            string access = form["laptopAccess"];

            int adminID = id;

            var adminUser = (from a in _db.AdminModels where a.ID == adminID select a).FirstOrDefault();

            if (ModelState.IsValid)
            {

                if (access == "true,false")
                {

                    access = "true";
                    adminUser.LaptopAccess = Convert.ToBoolean(access);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", admin);
                }
                else
                {
                    access = "false";
                    adminUser.LaptopAccess = Convert.ToBoolean(access);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", admin);

                }

            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogAccess(AdminModels admin, FormCollection form, int id)
        {
            string access = form["logAccess"];

            int adminID = id;

            var adminUser = (from a in _db.AdminModels where a.ID == adminID select a).FirstOrDefault();

            if (ModelState.IsValid)
            {

                if (access == "true,false")
                {

                    access = "true";
                    adminUser.LogAccess = Convert.ToBoolean(access);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", admin);
                }
                else
                {
                    access = "false";
                    adminUser.LogAccess = Convert.ToBoolean(access);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", admin);

                }

            }
            return View();
        }

     

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchAccess(AdminModels admin, FormCollection form, int id)
        {
            string access = form["searchAccess"];

            int adminID = id;

            var adminUser = (from a in _db.AdminModels where a.ID == adminID select a).FirstOrDefault();

            if (ModelState.IsValid)
            {

                if (access == "true,false")
                {

                    access = "true";
                    adminUser.SearchAccess = Convert.ToBoolean(access);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", admin);
                }
                else
                {
                    access = "false";
                    adminUser.SearchAccess = Convert.ToBoolean(access);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", admin);

                }

            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StoreAccess(AdminModels admin, FormCollection form, int id)
        {
            string access = form["storeAccess"];

            int adminID = id;

            var adminUser = (from a in _db.AdminModels where a.ID == adminID select a).FirstOrDefault();

            if (ModelState.IsValid)
            {

                if (access == "true,false")
                {

                    access = "true";
                    adminUser.StoreAccess = Convert.ToBoolean(access);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", admin);
                }
                else
                {
                    access = "false";
                    adminUser.StoreAccess = Convert.ToBoolean(access);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", admin);

                }

            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TransferAccess(AdminModels admin, FormCollection form, int id)
        {
            string access = form["transferAccess"];

            int adminID = id;

            var adminUser = (from a in _db.AdminModels where a.ID == adminID select a).FirstOrDefault();

            if (ModelState.IsValid)
            {

                if (access == "true,false")
                {

                    access = "true";
                    adminUser.TransferAccess = Convert.ToBoolean(access);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", admin);
                }
                else
                {
                    access = "false";
                    adminUser.TransferAccess = Convert.ToBoolean(access);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin", admin);

                }

            }
            return View();
        }



    }


}