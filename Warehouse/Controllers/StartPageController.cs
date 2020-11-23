using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class StartPageController : Controller
    {
        //Get StartPage Repository
        StartPageRepository startPageRepository = new StartPageRepository();

        // GET: StartPage
        public ActionResult Index()
        {

            try
            {
                
                if (startPageRepository.user(User.Identity.Name) == null)
                {
                    ViewBag.user = "new user";
                }
                else
                {
                    ViewBag.user = startPageRepository.user(User.Identity.Name).Name;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
              
            }
          
            return View();
        }
    }
}