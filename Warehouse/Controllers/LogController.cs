using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class LogController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Log


        //Get user info

        public string Username()
        {
            return User.Identity.GetUserName();
        }



        public LogModels logsList()
        {
            // Logs for Laptop

            List<LogModels> log = (from k in _db.LogModels where k.Type == "0" select k)
                                             .OrderBy(x => x.ID)
                                             .ToList();
            //Logs for Store
            List<LogModels> log1 = (from k in _db.LogModels where k.Type == "1" select k)
                                             .OrderBy(x => x.ID)
                                             .ToList();
            //Logs for Transfer
            List<LogModels> log2 = (from k in _db.LogModels where k.Type == "2" select k)
                                            .OrderBy(x => x.ID)
                                            .ToList();
            //Logs for Search
            List<LogModels> log3 = (from k in _db.LogModels where k.Type == "3" select k)
                                        .OrderBy(x => x.ID)
                                        .ToList();
            //Logs for Search - not found
            List<LogModels> log4 = (from k in _db.LogModels where k.Type == "4" select k)
                                       .OrderBy(x => x.ID)
                                       .ToList();
            //Logs for New user
            List<LogModels> log5 = (from k in _db.LogModels where k.Type == "5" select k)
                                      .OrderBy(x => x.ID)
                                      .ToList();

            //Logs for Admin console
            List<LogModels> log6 = (from k in _db.LogModels where k.Type == "6" select k)
                                      .OrderBy(x => x.ID)
                                      .ToList();

            //Logs for Access console
            List<LogModels> log7 = (from k in _db.LogModels where k.Type == "7" select k)
                                      .OrderBy(x => x.ID)
                                      .ToList();

            return new LogModels() { log = log, log1 = log1, log2 = log2, log3 = log3, log4 = log4, log5 = log5, log6 = log6, log7 = log7 };
        }



        public ActionResult Index()
        {

         
            try
            {


                return View(logsList());

  

            }
            catch (Exception e)
            {
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

}
}