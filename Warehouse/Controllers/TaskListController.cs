using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HandleError]
        public ActionResult Create(TaskListModels task, System.Web.Mvc.FormCollection form)
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
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult MyList(System.Web.Mvc.FormCollection form, int id)
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

        public ActionResult Details(int id)
        {
            try
            {
                TaskListModels task = new TaskListModels();

               task = (from t in _db.TaskListModels where t.ID == id select t).FirstOrDefault();

                TempData["assistant1"] = task.Assistant1;

                TempData["assistant2"] = task.Assistant2;

                TempData["assistant3"] = task.Assistant3;

                if (String.IsNullOrEmpty(task.Assistant1))
                {
                    TempData["assistant1"] = "not assigned yet";
                }

                if (String.IsNullOrEmpty(task.Assistant2))
                {
                    TempData["assistant2"] = "not assigned yet";
                }

                if (String.IsNullOrEmpty(task.Assistant3))
                {
                    TempData["assistant3"] = "not assigned yet";
                }

                ViewData["assistant1"] = _db.UserModels.ToList().Select(u => new SelectListItem
                {
                    Text = u.UserName,
                    Value = u.UserName
                }).ToList();

                ViewData["assistant2"] = _db.UserModels.ToList().Select(u => new SelectListItem
                {
                    Text = u.UserName,
                    Value = u.UserName
                }).ToList();

                ViewData["assistant3"] = _db.UserModels.ToList().Select(u => new SelectListItem
                {
                    Text = u.UserName,
                    Value = u.UserName
                }).ToList();


                return View(task);

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]

        public ActionResult Details(System.Web.Mvc.FormCollection form)
        {
            string assistantID1 = form["assistant1"].ToString();
            string assistantID2 = form["assistant2"].ToString();
            string assistantID3 = form["assistant3"].ToString();
            int id = Convert.ToInt32(form["ID"]);

            var task = (from t in _db.TaskListModels where t.ID==id select t).FirstOrDefault();

          
            if (!String.IsNullOrEmpty(assistantID1))
            {
                task.Assistant1 = assistantID1;
                _db.SaveChanges();
            }
            else if (!String.IsNullOrEmpty(assistantID2))
            {
                task.Assistant2 = assistantID2;
                _db.SaveChanges();
            }
            else if (!String.IsNullOrEmpty(assistantID3))
                {
                task.Assistant3 = assistantID3;
                _db.SaveChanges();
            }
            else
            {
                return RedirectToAction("MyList");
            }

            return RedirectToAction("MyList");
        }

       
    }
}