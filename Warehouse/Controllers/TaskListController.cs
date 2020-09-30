using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class TaskListController : Controller
    {
        // GET: TaskList

        private ApplicationDbContext _db = new ApplicationDbContext();

 
        public ActionResult Index()
        {
           ViewBag.user = User.Identity.GetUserName();   
           return View();
        }

        [HttpPost]
        public ActionResult Create(TaskListModels task, FormCollection form)
        {
            task.Details = form["Details"];
            task.User = User.Identity.GetUserName();
            _db.TaskListModels.Add(task);
            _db.SaveChanges();
            return View(task);
        }

        public ActionResult MyList()
        {
            try
            {
                var user = User.Identity.GetUserName();
                var list = (from l in _db.TaskListModels where l.User==user select l).ToList();
                return View(list);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
            //return View();
        }
    }
}