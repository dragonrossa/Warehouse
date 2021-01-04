using PagedList;
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
        Task<IPagedList<LogModels>> logLaptop10(int? page);
        Task<List<LogModels>> logDescLaptop();
        Task<IPagedList<LogModels>> logDescLaptop10(int? page);
        //2
        Task<List<LogModels>> logStore();
        Task<IPagedList<LogModels>> logStore20(int? page);
        Task<List<LogModels>> logDescStore();
        Task<IPagedList<LogModels>> logDescStore20(int? page);
        //3
        Task<List<LogModels>> logTransfer();
        Task<IPagedList<LogModels>> logTransfer30(int? page);
        Task<List<LogModels>> logDescTransfer();
        Task<IPagedList<LogModels>> logDescTranfer40(int? page);
        //4
        Task<List<LogModels>> logSearch();
        Task<IPagedList<LogModels>> logSearch40(int? page);
        Task<List<LogModels>> logDescSearch();
        Task<IPagedList<LogModels>> logDescSearch40(int? page);
        //5
        Task<List<LogModels>> logSearchNotFound();
        Task<IPagedList<LogModels>> logSearchNotFound50(int? page);
        Task<List<LogModels>> logDescSearchNotFound();
        Task<IPagedList<LogModels>> logDescSearchNotFound50(int? page);
        //6
        Task<List<LogModels>> logNewUser();
        Task<IPagedList<LogModels>> logNewUser60(int? page);
        Task<List<LogModels>> logDescNewUser();
        Task<IPagedList<LogModels>> logDescNewUser60(int? page);
        //7
        Task<List<LogModels>> logAdmin();
        Task<IPagedList<LogModels>> logAdmin70(int? page);
        Task<List<LogModels>> logDescAdmin();
        Task<IPagedList<LogModels>> logDescAdmin70(int? page);
        //8
        Task<List<LogModels>> logAccess();
        Task<IPagedList<LogModels>> logAccess80(int? page);
        Task<List<LogModels>> logDescAccess();
        Task<IPagedList<LogModels>> logDescAccess80(int? page);

        //Search
        Task<List<LogModels>> logSearchAsc(string searchString);
        Task<List<LogModels>> logSearchDesc(string searchString);
        //Save data
        Task<object> SaveData();
    }
}