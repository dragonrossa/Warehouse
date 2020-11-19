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
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //public ApplicationDbContext data()
        //{
            
        //    return _db;
        // }

        AdminModels admin = new AdminModels();

        //Get Admin Repository
        AdminRepository adminRepository = new AdminRepository();


        // GET: Admin
        public ActionResult Index()
        {

                try
                {
                return View(adminRepository.users());
                  //  return View(users());
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);

                    //redirect if there are no Laptopmodels in list
                    if (e.Message == "Sequence contains no elements")
                    {

                        //throw new UserNotFoundException();
                        // throw;
                        return RedirectToAction("NotFound");

                    }

                }
                finally
                {

                }
          
            return View();
        }

        //Exception - UserNotFound

        public ActionResult NotFound()
        {
            return View();
        }


        public ActionResult ChangeRole(int id)
        {

            TempData["UserID"] = id;                
            ViewBag.user = adminRepository.findUser(id).Name + " " + adminRepository.findUser(id).LastName;
            ViewBag.username = adminRepository.findUser(id).UserName;
            ViewBag.currentRole = adminRepository.currentRole(adminRepository.findUser(id));
            TempData["currentRole"] = ViewBag.currentRole;
            TempData["username"] = ViewBag.username;
            //List of available roles
            ViewData["roles"] = adminRepository.listOfRoles();
           // listOfRoles();

            return View(adminRepository.findUser(id));
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeRole(FormCollection form)
        {
          

            try
            {

                if (ModelState.IsValid)
                {
                    string roleID = form["Roles"]; 
                    admin.RoleID = Convert.ToInt32(roleID);
                    admin.Username = TempData["username"].ToString();

                    //if username is already in table update
                    //if username is not already in table create record

                    var username = adminRepository.findUsername(admin);
                    var user = adminRepository.user1(admin);
                    
                    if (admin.Username == username)
                    {

                        user.RoleID = Convert.ToInt32(roleID);
                        //Save db

                        adminRepository.SaveData();

                        //Create new log

                        var currentRole = adminRepository.getCurrentRole(user.RoleID);

                        adminRepository.log6(user.Username, currentRole);
                    }
                    else
                    {
                      //  _db.AdminModels.Add(admin);
                        adminRepository.Data(_db).AdminModels.Add(admin);

                        //Save db

                        adminRepository.SaveData();

                        //Create log

                        adminRepository.log6(user.Username, admin.RoleID);

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

               // _db.Entry(user).State = EntityState.Modified;

                    adminRepository.Data(_db).Entry(user).State = EntityState.Modified;


                    //Save db

                    adminRepository.SaveData();
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
           // List<AdminModels> access = (from a in _db.AdminModels where a.Username==username select a).ToList();

          //  access

            if (adminRepository.access(username).Count == 0)
            {

                adminRepository.adminListOfAccess(username);
            }

            return View(new AdminModels { access = adminRepository.access(username) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Access2(FormCollection form)
        {

            int userID = Convert.ToInt32(form["item.ID"]);

            //Save changes for user and create new log 

            adminRepository.log7(form, userID, adminRepository.adminUser(userID).Username);
 

            return RedirectToAction("Index","Admin");
        }

    }


}