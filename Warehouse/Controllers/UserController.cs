using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class UserController : Controller
    {
        //Get User Repository
        UserRepository userRepository = new UserRepository();

        // GET: User
        public ActionResult Index()
        {

            try
            {
                //Find and send users info to view

                userRepository.user(User.Identity.GetUserName());
                ViewBag.user = userRepository.user(User.Identity.GetUserName());
                ViewBag.date = DateTime.Now;
                return View(userRepository.userModels(User.Identity.GetUserName()));
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

                    userRepository.saveUser(userModels);
                    return RedirectToAction("Index", "Manage");
                }
                return View(userRepository.saveUser(userModels));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

        }
    }
}