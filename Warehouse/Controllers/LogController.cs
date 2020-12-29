using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Warehouse.DAL;
using Warehouse.Models;
using Warehouse.Repository;
using PagedList;

namespace Warehouse.Controllers
{
    public class LogController : Controller
    {
        //Get DB Context

        private WarehouseContext _db = new WarehouseContext();

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


        public async Task<ActionResult> Search(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var log = _db.LogModels.Where(s => s.Description.Contains(searchString)).ToListAsync();

                Session["search"] = searchString;

                return View("Search", new LogModels { logs1 = await log });
            }

            return RedirectToAction("Index");
        }

    //Exception - UserNotFound

    public async Task<ActionResult> NotFound()
    {
        return View();
    }

}
}