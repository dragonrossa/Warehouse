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
        public async Task<ActionResult> Index(string sortOrder, int? page)
        {

           try
            {
                //Paging and search

                ViewBag.CurrentSort = sortOrder;
                ViewBag.pageNumber = page ?? 1;


                int pageSize = 10;
                int pageNumber = page ?? 1;



                //Get ViewBag.pageCount
                ViewBag.pageCount = await logRepository.pageCount(pageSize);


                //Session for controllers

                Session["pageNumber"] = pageNumber;
                Session["pageSize"] = pageSize;


                return View(new LogModels { 
                    logs10 = await logRepository.pagedLaptopLog(page),
                    logs20 = await logRepository.pagedStoreLog(page),
                    logs30 = await logRepository.pagedTransferLog(page),
                    logs40 = await logRepository.pagedSearchLog(page),
                    logs50 = await logRepository.pagedSearchNotFoundLog(page),
                    logs60 = await logRepository.pagedNewUserLog(page),
                    logs70 = await logRepository.pagedAdminLog(page),
                    logs80 = await logRepository.pagedAccessLog(page),


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


        public async Task<ActionResult> Search(string searchString, string sortOrder, int? page)
        {


            //Paging and search

            ViewBag.CurrentSort = sortOrder;
            ViewBag.pageNumber = page ?? 1;


            int pageSize = 10;
            int pageNumber = page ?? 1;



            //Get ViewBag.pageCount
            ViewBag.pageCount = await logRepository.pageCount(pageSize);


            //Session for controllers

            Session["pageNumber"] = pageNumber;
            Session["pageSize"] = pageSize;


            if (!String.IsNullOrEmpty(searchString))
            {
                var log = _db.LogModels.Where(s => s.Description.Contains(searchString)).ToListAsync();

                Session["search"] = searchString;

                return View("Search", new LogModels { logs10 = await logRepository.logSearch(page, searchString) });

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