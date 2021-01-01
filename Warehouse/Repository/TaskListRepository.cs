using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Warehouse.DAL;
using Warehouse.Helpers;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class TaskListRepository: Controller, ITaskListRepository
    {
        // GET: TaskList

         private WarehouseContext _db = new WarehouseContext();

        List<TaskListModels> listOfTasks = new List<TaskListModels>();

        TaskListModels task = new TaskListModels();

        //Username of this user

        public async Task<string> user(string username)
        {
            var user = username;
            return user;
        }

        //Create task after submiting form
        public async Task<TaskListModels> createTask(TaskListModels task, System.Web.Mvc.FormCollection form, string username)
        {
            task.Details = form["Details"];
            task.User = await user(username);
            _db.TaskListModels.Add(task);
            await _db.SaveChangesAsync();
            return task;
        }

        //Get back list of false tasks to user
        public async Task<List<TaskListModels>> listOfFalseTasks()
        {
            bool status = false;
            var list = await (from l in _db.TaskListModels where l.Status == status select l).ToListAsync();
            return list;
        }

        //Change status after clicking on checkbox
        public async Task<TaskListModels> changeStatus(System.Web.Mvc.FormCollection form, int id)
        {
            var task = await (from t in _db.TaskListModels where t.ID == id select t).FirstOrDefaultAsync();
            string status = form["status"];
            task.Status = Convert.ToBoolean(form["status"]);
            await _db.SaveChangesAsync();
            return task;
        }

        //Find task by ID
        public async Task<TaskListModels> findTask(int id)
        {
            return await (from t in _db.TaskListModels where t.ID == id select t).FirstOrDefaultAsync();

        }


        //Select list for Assistant 1

        public async Task<List<SelectListItem>> assistant1()
        {
            return await _db.UserModels.Select(u => new SelectListItem
            {
                Text = u.UserName,
                Value = u.UserName
            }).ToListAsync();
        }

        //Select list for Assistant 2
        public async Task<List<SelectListItem>> assistant2()
        {
            return await _db.UserModels.Select(u => new SelectListItem
            {
                Text = u.UserName,
                Value = u.UserName
            }).ToListAsync();
        }

        //Select list for Assistant2
        public async Task<List<SelectListItem>> assistant3()
        {
            return await _db.UserModels.Select(u => new SelectListItem
            {
                Text = u.UserName,
                Value = u.UserName
            }).ToListAsync();
        }

        //Not assigned assistant 1
        public async Task<object> getAssistant1Info(int id)
        {
            var task = await findTask(id);

            if (String.IsNullOrEmpty(task.Assistant1))
            {
                TempData["assistant1"] = "not assigned yet";
            }


            return TempData["assistant1"];
        }

        //Not assigned assistant 2
        public async Task<object> getAssistant2Info(int id)
        {
            var task = await findTask(id);

            if (String.IsNullOrEmpty(task.Assistant2))
            {
                TempData["assistant2"] = "not assigned yet";
            }
            return TempData["assistant2"];
        }

        //Not assigned assistant 3
        public async Task<object> getAssistant3Info(int id)
        {
            var task = await findTask(id);

            if (String.IsNullOrEmpty(task.Assistant3))
            {
                TempData["assistant3"] = "not assigned yet";
            }
            return TempData["assistant3"];
        }

        //Save assistant1

        public async Task<string> setAssistant1(int id, string assistantID1)
        {
            var task = await findTask(id);

            if (!String.IsNullOrEmpty(assistantID1))
            {
                task.Assistant1 = assistantID1;
                await _db.SaveChangesAsync();

            }
            else
            {

            }

            return task.Assistant1;
        }

        //Save assistant2
        public async Task<string> setAssistant2(int id, string assistantID2)
        {

            var task = await findTask(id);

            if (!String.IsNullOrEmpty(assistantID2))
            {
                task.Assistant2 = assistantID2;
                await _db.SaveChangesAsync();
            }
            else
            {

            }
            return task.Assistant2;
        }

        //Save assistant3
        public async Task<string> setAssistant3(int id, string assistantID3)
        {
            var task = await findTask(id);
            if (!String.IsNullOrEmpty(assistantID3))
            {
                task.Assistant3 = assistantID3;
                await _db.SaveChangesAsync();
            }
            else
            {

            }
            return task.Assistant2;
        }

        //Upload file in Details section

        public async Task<byte[]> uploadFile(int id, HttpPostedFileBase postedFile)
        {
            byte[] bytes;

            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);

            }

            var str = System.Text.Encoding.Default.GetString(bytes);

            var task = await findTask(id);

            task.UploadName = postedFile.FileName;
            task.ContentType = postedFile.ContentType;
            task.Data = bytes;

            await _db.SaveChangesAsync();

            return bytes;


        }


        //Download previously uploaded file

        public async Task<FileContentResult> downloadFile(int? FileId)
        {
            TaskListModels taskList = new TaskListModels();
            var file = _db.TaskListModels.ToList().Find(p => p.ID == FileId);
            return File(file.Data, file.ContentType, file.UploadName);
        }

        //Delete uploaded file

        public async Task<TaskListModels> deleteFile(int? FileId2)
        {

            var file = await (from p in _db.TaskListModels where p.ID == FileId2 select p).FirstOrDefaultAsync();
            file.UploadName = null;
            file.ContentType = null;
            file.Data = null;
            await _db.SaveChangesAsync();
            return file;
        }

        //Properties

        public TransferModels lastInput
        {
            get
            {
                return (from k in _db.TransferModels
                        select k)
                               .OrderByDescending(k => k.ID)
                               .First();
            }
        }

        //Search and Paging

        public async Task<object> pageCount(int pageSize, TaskListModels task)
        {
            int pageCount = task.Child.Count();
            int pages = pageCount / pageSize;
            //ViewBag.pageCount = pages;
            int rest = pageCount % pageSize;
            if (rest < 10)
            {
                pages = pages + 1;
                ViewBag.pageCount = pages;
            }
            return ViewBag.pageCount;
        }

        //Get IPagedList for View

        public async Task<IPagedList<TaskListModels>> pagedTaskList(int? page)
        {
            listOfTasks = await listOfFalseTasks();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            return listOfTasks.ToPagedList(pageNumber, pageSize);

        }

        //Get IPagedList for Search
        public async Task<IPagedList<TaskListModels>> taskSearch(int? page, string searchString)
        {
            listOfTasks = await listOfFalseTasks();
            listOfTasks = listOfTasks.Where(s => s.User.Contains(searchString)).ToList();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            return listOfTasks.ToPagedList(pageNumber, pageSize);
        }

    }
}