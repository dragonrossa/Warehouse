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
        TaskListModels taskListModels = new TaskListModels();

        //Username of this user

        public string user()
        {
            var user = User.Identity.GetUserName();
            return user;
        }

        //Create task after submiting form
        public TaskListModels createTask(TaskListModels task, System.Web.Mvc.FormCollection form)
        {
            task.Details = form["Details"];
            task.User = User.Identity.GetUserName();
            _db.TaskListModels.Add(task);
            _db.SaveChanges();
            return task;
        }

        //Get back list of false tasks to user
        public List<TaskListModels> listOfFalseTasks()
        {
            bool status = false;
            var list = (from l in _db.TaskListModels where l.Status == status select l).ToList();
            return list;
        }

        //Change status after clicking on checkbox
        public TaskListModels changeStatus(System.Web.Mvc.FormCollection form, int id)
        {
            var task = (from t in _db.TaskListModels where t.ID == id select t).FirstOrDefault();
            string status = form["status"];
            task.Status = Convert.ToBoolean(form["status"]);
            _db.SaveChanges();
            return task;
        }

        //Find task by ID
        public TaskListModels findTask(int id)
        {
            return (from t in _db.TaskListModels where t.ID == id select t).FirstOrDefault();
        }

        //Select list for Assistant 1

        public List<SelectListItem> assistant1()
        {
            return _db.UserModels.ToList().Select(u => new SelectListItem
            {
                Text = u.UserName,
                Value = u.UserName
            }).ToList();
        }

        //Select list for Assistant 2
        public List<SelectListItem> assistant2()
        {
            return _db.UserModels.ToList().Select(u => new SelectListItem
            {
                Text = u.UserName,
                Value = u.UserName
            }).ToList();
        }

        //Select list for Assistant2
        public List<SelectListItem> assistant3()
        {
            return _db.UserModels.ToList().Select(u => new SelectListItem
                {
                    Text = u.UserName,
                    Value = u.UserName
                }).ToList();
        }

        public object getAssistant1Info(int id)
        {
            if (String.IsNullOrEmpty(findTask(id).Assistant1))
            {
                TempData["assistant1"] = "not assigned yet";
            }

            
            return TempData["assistant1"];
        }

        public object getAssistant2Info(int id)
        {
            if (String.IsNullOrEmpty(findTask(id).Assistant2))
            {
                TempData["assistant2"] = "not assigned yet";
            }
            return TempData["assistant2"];
        }

        public object getAssistant3Info(int id)
        {
           
            if (String.IsNullOrEmpty(findTask(id).Assistant3))
            {
                TempData["assistant3"] = "not assigned yet";
            }
            return TempData["assistant3"];
        }



        public ActionResult Index()
        {


            try
            {
                ViewBag.user = user();
                return View();
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

        public ActionResult NotFound()
        {
            return View();
        }

        [HttpPost]
        //[HandleError]
        public ActionResult Create(TaskListModels task, System.Web.Mvc.FormCollection form)
        {

            createTask(task, form);
            return RedirectToAction("MyList");
        }

        public ActionResult MyList()
        {
            try
            {
              
                return View(listOfFalseTasks());
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
                    changeStatus(form, id);

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
            

            return View(taskListModels.Child);
        }

        public ActionResult Details(int id)
        {
            try
            {
         
                TempData["assistant1"] = findTask(id).Assistant1;

                TempData["assistant2"] = findTask(id).Assistant2;

                TempData["assistant3"] = findTask(id).Assistant3;

                TempData["id"] = findTask(id).ID;


                //Get info if there are assistants checked from before
                getAssistant1Info(id);
                getAssistant2Info(id);
                getAssistant3Info(id);

                ViewData["assistant1"] = assistant1();
                ViewData["assistant2"] = assistant2();
                ViewData["assistant3"] = assistant3();
                
                return View(findTask(id));

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]

        public ActionResult Details(System.Web.Mvc.FormCollection form, HttpPostedFileBase postedFile)
        {
            string assistantID1 = form["assistant1"].ToString();
            string assistantID2 = form["assistant2"].ToString();
            string assistantID3 = form["assistant3"].ToString();
            int id = Convert.ToInt32(form["ID"]);
            ViewBag.id = id;
            
            var task = (from t in _db.TaskListModels where t.ID==id select t).FirstOrDefault();

            if (postedFile == null)
            {
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

            }
            else
            {
                byte[] bytes;

                using (BinaryReader br = new BinaryReader(postedFile.InputStream))
                {
                    bytes = br.ReadBytes(postedFile.ContentLength);

                }

                var str = System.Text.Encoding.Default.GetString(bytes);

                task.UploadName = postedFile.FileName;
                task.ContentType = postedFile.ContentType;
                task.Data = bytes;

                _db.SaveChanges();
            }



            return RedirectToAction("MyList");
        }

        [HttpPost]
        [HandleError]
        public FileResult DownloadFile(int? FileId)
        {
           
                TaskListModels taskList = new TaskListModels();
                var file = _db.TaskListModels.ToList().Find(p => p.ID == FileId);
                return File(file.Data, file.ContentType, file.UploadName); 
        }

        [HttpPost]
        [HandleError]
        public ActionResult DeleteFile(int? FileId2)
        {
            var id = FileId2;
            var file = (from p in _db.TaskListModels where p.ID == id select p).FirstOrDefault();
            file.UploadName = null;
            file.ContentType = null;
            file.Data = null;
            _db.SaveChanges();
            return RedirectToAction("MyList");
        }

    }
}