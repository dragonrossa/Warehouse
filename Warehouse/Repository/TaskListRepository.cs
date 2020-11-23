using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class TaskListRepository: Controller, ITaskListRepository
    {
        // GET: TaskList

         private ApplicationDbContext _db = new ApplicationDbContext();
      //  TaskListModels taskListModels = new TaskListModels();

        //Username of this user

        public string user(string username)
        {
            var user = username;
            return user;
        }

        //Create task after submiting form
        public TaskListModels createTask(TaskListModels task, System.Web.Mvc.FormCollection form, string username)
        {
            task.Details = form["Details"];
            task.User = user(username);
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

        public string setAssistant1(int id, string assistantID1)
        {


            if (!String.IsNullOrEmpty(assistantID1))
            {
                findTask(id).Assistant1 = assistantID1;
                _db.SaveChanges();

            }
            else
            {

            }

            return findTask(id).Assistant1;
        }

        public string setAssistant2(int id, string assistantID2)
        {


            if (!String.IsNullOrEmpty(assistantID2))
            {
                findTask(id).Assistant2 = assistantID2;
                _db.SaveChanges();
            }
            else
            {

            }
            return findTask(id).Assistant2;
        }

        public string setAssistant3(int id, string assistantID3)
        {

            if (!String.IsNullOrEmpty(assistantID3))
            {
                findTask(id).Assistant3 = assistantID3;
                _db.SaveChanges();
            }
            else
            {

            }
            return findTask(id).Assistant2;
        }

        //Upload file in Details section

        public byte[] uploadFile(int id, HttpPostedFileBase postedFile)
        {
            byte[] bytes;

            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);

            }

            var str = System.Text.Encoding.Default.GetString(bytes);

            findTask(id).UploadName = postedFile.FileName;
            findTask(id).ContentType = postedFile.ContentType;
            findTask(id).Data = bytes;

            _db.SaveChanges();

            return bytes;


        }


        //Download previously uploaded file

        public FileContentResult downloadFile(int? FileId)
        {
            TaskListModels taskList = new TaskListModels();
            var file = _db.TaskListModels.ToList().Find(p => p.ID == FileId);
            return File(file.Data, file.ContentType, file.UploadName);
        }

        //Delete uploaded file

        public TaskListModels deleteFile(int? FileId2)
        {

            var file = (from p in _db.TaskListModels where p.ID == FileId2 select p).FirstOrDefault();
            file.UploadName = null;
            file.ContentType = null;
            file.Data = null;
            _db.SaveChanges();
            return file;
        }

    }
}