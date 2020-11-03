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

        //Username of this user
        public string user()
        {
            var user = User.Identity.GetUserName();
            return user;
        }

        //Users list of details
        public UserModels userModels(string user)
        {
            UserModels userModels = (from k in _db.UserModels where k.Mail == user select k).First();
            return userModels;
        }

        //Save this users details after editing

        public UserModels saveUser(UserModels userModels)
        {
            _db.Entry(userModels).State = EntityState.Modified;
            userModels.DateModified = DateTime.Now;
            _db.SaveChanges();
            return userModels;
        }


        // GET: User
        public ActionResult Index()
        {

            try
            {
                //Find and send users info to view
                userModels(user());
                ViewBag.user = user();
                ViewBag.date = DateTime.Now;
                return View(userModels(user()));
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

            return View();

        }


        //Exception - UserNotFound

        public ActionResult NotFound()
        {
            return View();
        }


        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserModels userModels)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    saveUser(userModels);
                    return RedirectToAction("Index", "Manage");
                }
                return View(saveUser(userModels));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

        }
    }
}