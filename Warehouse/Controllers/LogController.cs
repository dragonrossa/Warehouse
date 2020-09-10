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
        public ActionResult Index()
        {
            //Logs for Laptop
            List<LogModels> log = (from k in _db.LogModels where k.Type=="0" select k)
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
            List<LogModels> log3 = (from k in _db.LogModels where k.Type == "3" select k)
                                        .OrderBy(x => x.ID)
                                        .ToList();

            List<LogModels> log4 = (from k in _db.LogModels where k.Type == "4" select k)
                                       .OrderBy(x => x.ID)
                                       .ToList();
            //return View(log);

            return View(new LogModels() { log = log, log1 = log1, log2 = log2, log3 = log3 , log4 = log4});
        }

    }
}