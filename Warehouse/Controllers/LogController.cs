using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class LogController : Controller
    {

        //Get Log Repository
        LogRepository logRepository = new LogRepository();

    
        // GET: Log
        public ActionResult Index()
        {

            try
            {

                return View(
                    new LogModels
                    {
                        logs1 = logRepository.logLaptop(),
                        logs2 = logRepository.logStore(),
                        logs3 = logRepository.logTransfer(),
                        logs4 = logRepository.logSearch(),
                        logs5 = logRepository.logSearchNotFound(),
                        logs6 = logRepository.logNewUser(),
                        logs7 = logRepository.logAdmin(),
                        logs8 = logRepository.logAccess()
                    }); 
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