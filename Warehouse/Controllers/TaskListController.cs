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
        public async Task<ActionResult> Index()
        {

            try
            {
                ViewBag.user = await taskListRepository.user(User.Identity.GetUserName());
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

        public async Task<ActionResult> NotFound()
        {
            return View();
        }

        [HttpPost]
        //[HandleError]
        public async Task<ActionResult> Create(TaskListModels task, System.Web.Mvc.FormCollection form)
        {

            await taskListRepository.createTask(task, form, User.Identity.GetUserName());
            return RedirectToAction("MyList");
        }

        public async Task<ActionResult> MyList(string sortOrder, int? page)
        {
            try
            {
                //Paging and search

                ViewBag.CurrentSort = sortOrder;
                ViewBag.pageNumber = page ?? 1;


                int pageSize = 10;
                int pageNumber = page ?? 1;



                //Get ViewBag.pageCount
                await taskListRepository.pageCount(pageSize, taskListModels);


                //Session for controllers

                Session["pageNumber"] = pageNumber;
                Session["pageSize"] = pageSize;

                var lastInput = taskListRepository.lastInput;

                ViewBag.laptop = taskListRepository.lastInput.LaptopName;
                ViewBag.date = taskListRepository.lastInput.Date;
                ViewBag.quantity = taskListRepository.lastInput.LaptopQuantity;

                return View(await taskListRepository.pagedTaskList(page));

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
        public async Task<ActionResult> MyList(System.Web.Mvc.FormCollection form, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await taskListRepository.changeStatus(form, id);

                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            return View();
          
        }

        public async Task<ActionResult> Search(string searchString, int? page)
        {

            //Search box

            if (!String.IsNullOrEmpty(searchString))
            {

                return View("MyList",await taskListRepository.taskSearch(page, searchString));
            }

            return RedirectToAction("MyList");
        }

        public async Task<ActionResult> List()
        {
            

            return View(
                new TaskListModels
            {
                task =
                taskListModels.Child
            });
        }

        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var task = await taskListRepository.findTask(id);


                TempData["assistant1"] = Convert.ToString(task.Assistant1);

                TempData["assistant2"] = Convert.ToString(task.Assistant2);

                TempData["assistant3"] = Convert.ToString(task.Assistant3);

                TempData["id"] = task.ID;


                //Get info if there are assistants checked from before
                await taskListRepository.getAssistant1Info(id);
                await taskListRepository.getAssistant2Info(id);
                await taskListRepository.getAssistant3Info(id);

                ViewData["assistant1"] = await taskListRepository.assistant1();
                ViewData["assistant2"] = await taskListRepository.assistant2();
                ViewData["assistant3"] = await taskListRepository.assistant3();
                
                return View(await taskListRepository.findTask(id));

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Details(System.Web.Mvc.FormCollection form, HttpPostedFileBase postedFile)
        {
            
            //Send to ViewBag
            int id = Convert.ToInt32(form["ID"]);
            ViewBag.id = id;

            if (postedFile == null)
            {

                //Set assistants to user

                await taskListRepository.setAssistant1(id, form["assistant1"].ToString());
                await taskListRepository.setAssistant2(id, form["assistant2"].ToString());
                await taskListRepository.setAssistant3(id, form["assistant3"].ToString());

            }
            else
            {

                //Set assistants
                await taskListRepository.setAssistant1(id, form["assistant1"].ToString());
                await taskListRepository.setAssistant2(id, form["assistant2"].ToString());
                await taskListRepository.setAssistant3(id, form["assistant3"].ToString());

                //Save uploaded file
                await taskListRepository.uploadFile(id, postedFile);
            }



            return RedirectToAction("MyList");
        }

        [HttpPost]
        [HandleError]
        public async Task<FileResult> DownloadFile(int? FileId)
        {

           return await taskListRepository.downloadFile(FileId);
        }

        [HttpPost]
        [HandleError]
        public async Task<ActionResult> DeleteFile(int? FileId2)
        {

            await taskListRepository.deleteFile(FileId2);
            return RedirectToAction("MyList");
        }

    }
}