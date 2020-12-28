using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface ILogRepository
    {
        //Get context
        WarehouseContext Data(WarehouseContext _db);
        //Get log list for every type
        //1
        Task<List<LogModels>> logLaptop();
        Task<List<LogModels>> logDescLaptop();
        //2
        Task<List<LogModels>> logStore();
        Task<List<LogModels>> logDescStore();
        //3
        Task<List<LogModels>> logTransfer();
        Task<List<LogModels>> logDescTransfer();
        //4
        Task<List<LogModels>> logSearch();
        Task<List<LogModels>> logDescSearch();
        //5
        Task<List<LogModels>> logSearchNotFound();
        Task<List<LogModels>> logDescSearchNotFound();
        //6
        Task<List<LogModels>> logNewUser();
        Task<List<LogModels>> logDescNewUser();
        //7
        Task<List<LogModels>> logAdmin();
        Task<List<LogModels>> logDescAdmin();
        //8
        Task<List<LogModels>> logAccess();
        Task<List<LogModels>> logDescAccess();

        //Search
        Task<List<LogModels>> logSearchAsc(string searchString);
        Task<List<LogModels>> logSearchDesc(string searchString);
        //Save data
        Task<object> SaveData();
    }
}