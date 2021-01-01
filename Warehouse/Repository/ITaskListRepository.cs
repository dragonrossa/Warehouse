using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface ITaskListRepository
    {
        //Username of this user
        Task<string> user(string username);
        //Create task after submiting form
        Task<TaskListModels> createTask(TaskListModels task, System.Web.Mvc.FormCollection form, string username);
        //Get back list of false tasks to user
        Task<List<TaskListModels>> listOfFalseTasks();
        //Change status after clicking on checkbox
        Task<TaskListModels> changeStatus(System.Web.Mvc.FormCollection form, int id);
        //Find task by ID
        Task<TaskListModels> findTask(int id);
        //Select list for Assistant 1
        Task<List<SelectListItem>> assistant1();
        //Select list for Assistant 2
        Task<List<SelectListItem>> assistant2();
        //Select list for Assistant2
        Task<List<SelectListItem>> assistant3();
        //Not assigned assistant 1
        Task<object> getAssistant1Info(int id);
        //Not assigned assistant 2
        Task<object> getAssistant2Info(int id);
        //Not assigned assistant 3
        Task<object> getAssistant3Info(int id);
        //Save assistant1
        Task<string> setAssistant1(int id, string assistantID1);
        //Save assistant2
        Task<string> setAssistant2(int id, string assistantID2);
        //Save assistant3
        Task<string> setAssistant3(int id, string assistantID3);
        //Upload file in Details section
        Task<byte[]> uploadFile(int id, HttpPostedFileBase postedFile);
        //Download previously uploaded file
        Task<FileContentResult> downloadFile(int? FileId);
        //Delete uploaded file
        Task<TaskListModels> deleteFile(int? FileId2);
        //Search and Paging
        Task<object> pageCount(int pageSize, TaskListModels task);
        //Get IPagedList for View
        Task<IPagedList<TaskListModels>> pagedTaskList(int? page);
        //Get IPagedList for Search
        Task<IPagedList<TaskListModels>> taskSearch(int? page, string searchString);
    }
}