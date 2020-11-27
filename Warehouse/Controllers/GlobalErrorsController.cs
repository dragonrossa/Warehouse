using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Warehouse.Controllers
{
    public class GlobalErrorsController : Controller
    {
        // GET: GlobalErrors
        public ActionResult Index()
        {
            return View();
        }
    }
}