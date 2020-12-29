using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Warehouse.DAL;
using Warehouse.Models;
using Warehouse.Repository;
using PagedList;

namespace Warehouse.Controllers
{
    public class TaskListController : Controller
    {
        //Get DB Context

        private WarehouseContext _db = new WarehouseContext();

        //Get TaskList Repository

        TaskListRepository taskListRepository = new TaskListRepository();

        //TaskListModels object
        TaskListModels taskListModels = new TaskListModels();


        // GET: TaskList
        public ActionResult Index()
        {

            try
            {
                ViewBag.user = taskListRepository.user(User.Identity.GetUserName());
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

            taskListRepository.createTask(task, form, User.Identity.GetUserName());
            return RedirectToAction("MyList");
        }

        public async Task<ActionResult> MyList()
        {
            try
            {
                
                return View(new TaskListModels { task = taskListRepository.listOfFalseTasks() });
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
                    taskListRepository.changeStatus(form, id);

                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            return View();
          
        }

        public async Task<ActionResult> Search(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var taskUser = _db.TaskListModels.Where(s => s.User.Contains(searchString)).ToListAsync();

                return View("MyList", new TaskListModels { task = await taskUser });
            }

            return RedirectToAction("MyList");
        }

        public ActionResult List()
        {
            

            return View(
                new TaskListModels
            {
                task =
                taskListModels.Child
            });
        }

        public ActionResult Details(int id)
        {
            try
            {
         
                TempData["assistant1"] = taskListRepository.findTask(id).Assistant1;

                TempData["assistant2"] = taskListRepository.findTask(id).Assistant2;

                TempData["assistant3"] = taskListRepository.findTask(id).Assistant3;

                TempData["id"] = taskListRepository.findTask(id).ID;


                //Get info if there are assistants checked from before
                taskListRepository.getAssistant1Info(id);
                taskListRepository.getAssistant2Info(id);
                taskListRepository.getAssistant3Info(id);

                ViewData["assistant1"] = taskListRepository.assistant1();
                ViewData["assistant2"] = taskListRepository.assistant2();
                ViewData["assistant3"] = taskListRepository.assistant3();
                
                return View(taskListRepository.findTask(id));

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
            
            //Send to ViewBag
            int id = Convert.ToInt32(form["ID"]);
            ViewBag.id = id;

            if (postedFile == null)
            {

                //Set assistants to user

                taskListRepository.setAssistant1(id, form["assistant1"].ToString());
                taskListRepository.setAssistant2(id, form["assistant2"].ToString());
                taskListRepository.setAssistant3(id, form["assistant3"].ToString());

            }
            else
            {

                //Set assistants
                taskListRepository.setAssistant1(id, form["assistant1"].ToString());
                taskListRepository.setAssistant2(id, form["assistant2"].ToString());
                taskListRepository.setAssistant3(id, form["assistant3"].ToString());

                //Save uploaded file
                taskListRepository.uploadFile(id, postedFile);
            }



            return RedirectToAction("MyList");
        }

        [HttpPost]
        [HandleError]
        public FileResult DownloadFile(int? FileId)
        {

           return taskListRepository.downloadFile(FileId);
        }

        [HttpPost]
        [HandleError]
        public ActionResult DeleteFile(int? FileId2)
        {

            taskListRepository.deleteFile(FileId2);
            return RedirectToAction("MyList");
        }

    }
}