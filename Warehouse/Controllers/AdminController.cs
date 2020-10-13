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



        //Access for all users

        public ActionResult Access2( string username)

        {
            List<AdminModels> access = (from a in _db.AdminModels where a.Username==username select a).ToList();

            return View(new AdminModels { access = access });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Access2(FormCollection form)
        {

            int userID = Convert.ToInt32(form["item.ID"]);
            string username = form["item.Username"];
            string access = form["item.Access"];
            string laptopAccess = form["item.LaptopAccess"];
            string logAccess = form["item.LogAccess"];
            string searchAccess = form["item.SearchAccess"];
            string storeAccess = form["item.StoreAccess"];
            string transferAccess = form["item.TransferAccess"];
            string taskAccess = form["item.TaskAccess"];

            
            var user = (from u in _db.AdminModels where u.ID == userID select u).FirstOrDefault();


            bool a = access == "true,false" ? user.Access = Convert.ToBoolean("true") : user.Access = Convert.ToBoolean("false");
            bool b = laptopAccess == "true,false" ? user.LaptopAccess = Convert.ToBoolean("true") : user.LaptopAccess = Convert.ToBoolean("false");
            bool c = logAccess == "true,false" ? user.LogAccess = Convert.ToBoolean("true") : user.LogAccess = Convert.ToBoolean("false");
            bool d = searchAccess == "true,false" ? user.SearchAccess = Convert.ToBoolean("true") : user.SearchAccess = Convert.ToBoolean("false");
            bool e = storeAccess == "true,false" ? user.StoreAccess = Convert.ToBoolean("true") : user.StoreAccess = Convert.ToBoolean("false");
            bool f = transferAccess == "true,false" ? user.TransferAccess = Convert.ToBoolean("true") : user.TransferAccess = Convert.ToBoolean("false");
            bool g = taskAccess == "true,false" ? user.TaskAccess = Convert.ToBoolean("true") : user.TaskAccess = Convert.ToBoolean("false");


            string[] userAccess = { "Admin access", "Laptop access", " Log access", "Search access", "Store access", "Transfer access", "Task access" };

            string[] rights = { Convert.ToString(a), Convert.ToString(b), Convert.ToString(c), Convert.ToString(d), Convert.ToString(e), Convert.ToString(f), Convert.ToString(g)};


            for (int i = 0; i < userAccess.Length; i++) {

                LogModels log = new LogModels
                {
                    Type = "7",
                    Description = "New change was made for user " + user.Username + " on date " + DateTime.Now + " granting access:" + rights[i] + " for " + userAccess[i] ,
                    Date = DateTime.Now
                };

                _db.LogModels.Add(log);
                _db.SaveChanges();
            }

            return RedirectToAction("Index","Admin");
        }

    }


}