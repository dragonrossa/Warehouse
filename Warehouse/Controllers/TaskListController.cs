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
                bool status = false;
                var list = (from l in _db.TaskListModels where l.Status==status select l).ToList();
                
                return View(list);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyList(FormCollection form, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var task = (from t in _db.TaskListModels where t.ID == id select t).FirstOrDefault();
                    string status = form["status"];
                    task.Status = Convert.ToBoolean(form["status"]);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            return View();
          
        }

        public ActionResult List()
        {
            List<TaskListModels> taskListModels = new List<TaskListModels>();

            taskListModels = (from t in _db.TaskListModels select t).ToList();

            return View(taskListModels);
        }
    }
}