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
            List<LogModels> log = (from k in _db.LogModels select k)
                                             .OrderBy(x => x.ID)
                                             .ToList();
            return View(log);
        }
    }
}