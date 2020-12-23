using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {

            try
            {

                return View(
                    new LogModels
                    {
                        logs1 = await logRepository.logLaptop(),
                        logs2 = await logRepository.logStore(),
                        logs3 = await logRepository.logTransfer(),
                        logs4 = await logRepository.logSearch(),
                        logs5 = await logRepository.logSearchNotFound(),
                        logs6 = await logRepository.logNewUser(),
                        logs7 = await logRepository.logAdmin(),
                        logs8 = await logRepository.logAccess()
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

    public async Task<ActionResult> NotFound()
    {
        return View();
    }

}
}