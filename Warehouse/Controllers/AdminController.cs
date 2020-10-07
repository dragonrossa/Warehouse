using Microsoft.AspNet.Identity;
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
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeRole(FormCollection form)
        {
          
            AdminModels admin = new AdminModels();

            try
            {

                if (ModelState.IsValid)
                {
                    string roleID = form["Roles"]; //1 for Chief
                    admin.RoleID = Convert.ToInt32(roleID);
                    admin.Username = TempData["username"].ToString();

                    //if username is already in table update
                    //if username is not already in table create record

                    var username = (from u in _db.AdminModels where u.Username == admin.Username select u.Username).FirstOrDefault();
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
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {

            }

            return RedirectToAction("Index", "Admin", new { });

        }

        public ActionResult ChangeDetails(int id)
        {
            try
            {

                TempData["UserID"] = id;


                if (ModelState.IsValid)
                {

                    UserModels user = _db.UserModels.Find(id);

                    return View(user);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {

            }

            return View();
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeDetails(UserModels user)
        {
            try
            {

            if (ModelState.IsValid)
            {

                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", "Admin", user);

            }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return View();
        }

        public ActionResult Access(int id)
        {
            try
            {
                TempData["UserID"] = id;


                var user = (from u in _db.UserModels where u.ID == id select u).FirstOrDefault();


                if (ModelState.IsValid)
                {

                    AdminModels admin = (from a in _db.AdminModels where a.Username == user.UserName select a).FirstOrDefault();
                    TempData["AdminID"] = admin.ID;
                    return View(admin);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Access(AdminModels admin, FormCollection form, int id)
        {
            try
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
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.Access + " for Admin access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);
                    }
                    else
                    {
                        access = "false";
                        adminUser.Access = Convert.ToBoolean(access);
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.Access + " for Admin access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {

            }

            return View();
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult LaptopAccess(AdminModels admin, FormCollection form, int id)
        {
            try
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
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.LaptopAccess + " for Laptop access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);
                    }
                    else
                    {
                        access = "false";
                        adminUser.LaptopAccess = Convert.ToBoolean(access);
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.LaptopAccess + " for Laptop access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {

            }

            return View();
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult LogAccess(AdminModels admin, FormCollection form, int id)
        {
            try
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
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.LogAccess + " for Log access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);
                    }
                    else
                    {
                        access = "false";
                        adminUser.LogAccess = Convert.ToBoolean(access);
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.LogAccess + " for Log access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {

            }

            return View();
        }

     

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult SearchAccess(AdminModels admin, FormCollection form, int id)
        {
            try
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
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.SearchAccess + " for Search access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);
                    }
                    else
                    {
                        access = "false";
                        adminUser.SearchAccess = Convert.ToBoolean(access);
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.SearchAccess + " for Search access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {

            }
            return View();
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult StoreAccess(AdminModels admin, FormCollection form, int id)
        {
            try
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
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.StoreAccess + " for Store access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);
                    }
                    else
                    {
                        access = "false";
                        adminUser.StoreAccess = Convert.ToBoolean(access);
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.StoreAccess + " for Store access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {

            }
            return View();
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult TransferAccess(AdminModels admin, FormCollection form, int id)
        {
            try
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
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.TransferAccess + " for Transfer access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);
                    }
                    else
                    {
                        access = "false";
                        adminUser.TransferAccess = Convert.ToBoolean(access);
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.TransferAccess + " for Transfer access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {

            }
            return View();
        }




        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult TaskAccess(AdminModels admin, FormCollection form, int id)
        {
            try
            {


                string access = form["taskAccess"];

                int adminID = id;

                var adminUser = (from a in _db.AdminModels where a.ID == adminID select a).FirstOrDefault();

                if (ModelState.IsValid)
                {

                    if (access == "true,false")
                    {

                        access = "true";
                        adminUser.TaskAccess = Convert.ToBoolean(access);
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.TaskAccess + " for Task access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);
                    }
                    else
                    {
                        access = "false";
                        adminUser.TaskAccess = Convert.ToBoolean(access);
                        LogModels log = new LogModels
                        {
                            Type = "7",
                            Description = "New change was made for user " + admin.Username + " on date " + DateTime.Now + " granting access:" + adminUser.TaskAccess + " for Task access.",
                            Date = DateTime.Now
                        };

                        _db.LogModels.Add(log);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Admin", admin);

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {

            }
            return View();
        }




    }


}