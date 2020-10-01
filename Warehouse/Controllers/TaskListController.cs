using Microsoft.AspNet.Identity;
using Microsoft.Owin;
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

                TaskListModels task = new TaskListModels();

                task = (from t in _db.TaskListModels where t.ID == id select t).FirstOrDefault();

                return View(task);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Details(System.Web.Mvc.FormCollection form)
        {
            string assistantID1 = form["assistant1"].ToString();
            string assistantID2 = form["assistant2"].ToString();
            string assistantID3 = form["assistant3"].ToString();
            int id = Convert.ToInt32(form["ID"]);

            var task = (from t in _db.TaskListModels where t.ID==id select t).FirstOrDefault();

            if(assistantID1 != null)
            {
                task.Assistant1 = assistantID1;
            }
            else
            {
                return RedirectToAction("MyList");
            }

            if(assistantID2 != null)
            {
                task.Assistant2 = assistantID2;
            }

            else
            {
                return RedirectToAction("MyList");
            }

            if(assistantID3 != null)
            {
                task.Assistant3 = assistantID3;
            }
            else
            {
                return RedirectToAction("MyList");
            }

            _db.SaveChanges();

            return RedirectToAction("MyList");
        }
    }
}