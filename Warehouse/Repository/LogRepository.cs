using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Warehouse.Models;
using System.Data.Entity;
using Warehouse.DAL;
using PagedList;
using System.Web.Mvc;

namespace Warehouse.Repository
{
    public class LogRepository : Controller, ILogRepository
    {
        //Get DB Context
        private WarehouseContext _db = new WarehouseContext();

        //Create new List

        List<LogModels> logs = new List<LogModels>();

        //Get PageParameters object

        PageParameters pages = new PageParameters();

        //Get DB
        public WarehouseContext Data(WarehouseContext _db)
        {

            this._db = _db;
            return _db;
        }

        //1 - asc

        public async Task<List<LogModels>> logLaptop()
        {
            return await (from k in _db.LogModels where k.Type == "0" select k)
                                              .OrderBy(x => x.ID)
                                              .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logLaptop10(int? page)
        {
            var laptop = await (from k in _db.LogModels where k.Type == "0" select k)
                                              .OrderBy(x => x.ID)
                                              .ToListAsync();

            return laptop.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //desc

        public async Task<List<LogModels>> logDescLaptop()
        {
            return await (from k in _db.LogModels where k.Type == "0" select k)
                                              .OrderByDescending(x => x.ID)
                                              .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logDescLaptop10(int? page)
        {
            var laptop = await (from k in _db.LogModels where k.Type == "0" select k)
                                              .OrderByDescending(x => x.ID)
                                              .ToListAsync();
            return laptop.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //2 - asc

        public async Task<List<LogModels>> logStore()
        {
            return await (from k in _db.LogModels where k.Type == "1" select k)
                                             .OrderBy(x => x.ID)
                                             .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logStore20(int? page)
        {
            var store = await (from k in _db.LogModels where k.Type == "1" select k)
                                             .OrderBy(x => x.ID)
                                             .ToListAsync();

            return store.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //desc

        public async Task<List<LogModels>> logDescStore()
        {
            return await (from k in _db.LogModels where k.Type == "1" select k)
                                             .OrderByDescending(x => x.ID)
                                             .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logDescStore20(int? page)
        {
            var store = await (from k in _db.LogModels where k.Type == "1" select k)
                                             .OrderByDescending(x => x.ID)
                                             .ToListAsync();

            return store.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //3 - asc

        public async Task<List<LogModels>> logTransfer()
        {
            return await (from k in _db.LogModels where k.Type == "2" select k)
                                            .OrderBy(x => x.ID)
                                            .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logTransfer30(int? page)
        {
            var log =  await (from k in _db.LogModels where k.Type == "2" select k)
                                            .OrderBy(x => x.ID)
                                            .ToListAsync();

            return log.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //desc

        public async Task<List<LogModels>> logDescTransfer()
        {
            return await (from k in _db.LogModels where k.Type == "2" select k)
                                            .OrderByDescending(x => x.ID)
                                            .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logDescTransfer30(int? page)
        {
            var log = await (from k in _db.LogModels where k.Type == "2" select k)
                                            .OrderByDescending(x => x.ID)
                                            .ToListAsync();

            return log.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //4 - asc

        public async Task<List<LogModels>> logSearch()
        {
            return await (from k in _db.LogModels where k.Type == "3" select k)
                                        .OrderBy(x => x.ID)
                                        .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logSearch40(int? page)
        {
            var log = await (from k in _db.LogModels where k.Type == "3" select k)
                                        .OrderBy(x => x.ID)
                                        .ToListAsync();

            return log.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //desc 
        public async Task<List<LogModels>> logDescSearch()
        {
            return await (from k in _db.LogModels where k.Type == "3" select k)
                                        .OrderByDescending(x => x.ID)
                                        .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logDescSearch40(int? page)
        {
            var log = await (from k in _db.LogModels where k.Type == "3" select k)
                                        .OrderByDescending(x => x.ID)
                                        .ToListAsync();

            return log.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //5 - asc

        public async Task<List<LogModels>> logSearchNotFound()
        {
            return await (from k in _db.LogModels where k.Type == "4" select k)
                                       .OrderBy(x => x.ID)
                                       .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logSearchNotFound50(int? page)
        {
            var search = await (from k in _db.LogModels where k.Type == "4" select k)
                                       .OrderBy(x => x.ID)
                                       .ToListAsync();

            return search.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //desc
        public async Task<List<LogModels>> logDescSearchNotFound()
        {
            return await (from k in _db.LogModels where k.Type == "4" select k)
                                       .OrderBy(x => x.ID)
                                       .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logDescSearchNotFound50(int? page)
        {
            var search = await (from k in _db.LogModels where k.Type == "4" select k)
                                       .OrderBy(x => x.ID)
                                       .ToListAsync();

            return search.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //6 - asc

        public async Task<List<LogModels>> logNewUser()
        {
            return await (from k in _db.LogModels where k.Type == "5" select k)
                                      .OrderBy(x => x.ID)
                                      .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logNewUser60(int? page)
        {
            var user = await (from k in _db.LogModels where k.Type == "5" select k)
                                      .OrderBy(x => x.ID)
                                      .ToListAsync();

            return user.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }
        //desc

        public async Task<List<LogModels>> logDescNewUser()
        {
            return await (from k in _db.LogModels where k.Type == "5" select k)
                                      .OrderByDescending(x => x.ID)
                                      .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logDescNewUser60(int? page)
        {
            var user = await (from k in _db.LogModels where k.Type == "5" select k)
                                      .OrderByDescending(x => x.ID)
                                      .ToListAsync();
            return user.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //7 - asc

        public async Task<List<LogModels>> logAdmin()
        {
            return await (from k in _db.LogModels where k.Type == "6" select k)
                                      .OrderBy(x => x.ID)
                                      .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logAdmin70(int? page)
        {
            var admin = await (from k in _db.LogModels where k.Type == "6" select k)
                                      .OrderBy(x => x.ID)
                                      .ToListAsync();

            return admin.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //desc
        public async Task<List<LogModels>> logDescAdmin()
        {
            return await (from k in _db.LogModels where k.Type == "6" select k)
                                      .OrderByDescending(x => x.ID)
                                      .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logDescAdmin70(int? page)
        {
            var admin = await (from k in _db.LogModels where k.Type == "6" select k)
                                      .OrderByDescending(x => x.ID)
                                      .ToListAsync();

            return admin.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //8 - asc

        public async Task<List<LogModels>> logAccess()
        {
            return await (from k in _db.LogModels where k.Type == "7" select k)
                                      .OrderBy(x => x.ID)
                                      .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logAccess80(int? page)
        {
            var access = await (from k in _db.LogModels where k.Type == "7" select k)
                                      .OrderBy(x => x.ID)
                                      .ToListAsync();

            return access.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }


        //desc
        public async Task<List<LogModels>> logDescAccess()
        {
            return await (from k in _db.LogModels where k.Type == "7" select k)
                                      .OrderByDescending(x => x.ID)
                                      .ToListAsync();
        }

        public async Task<IPagedList<LogModels>> logDescAccess80(int? page)
        {
            var access = await (from k in _db.LogModels where k.Type == "7" select k)
                                      .OrderByDescending(x => x.ID)
                                      .ToListAsync();

            return access.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }


        //desc
        public async Task<List<LogModels>> allLogs()
        {
            return await (from k in _db.LogModels select k)
                                      .OrderByDescending(x => x.ID)
                                      .ToListAsync();
        }
        //asc

        public async Task<IPagedList<LogModels>> logSearchAsc(string searchString, int? page)
        {
            var list = await _db.LogModels
                .OrderBy(s => s.Date)
                .Where(s => s.Description.Contains(searchString)).ToListAsync();

            return list.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        //desc
        public async Task<IPagedList<LogModels>> logSearchDesc(string searchString, int? page)
        {
           
           var list = await _db.LogModels
                .OrderByDescending(s=>s.Date)
                .Where(s => s.Description.Contains(searchString)).ToListAsync();

            return list.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }


        //Save DB
        public async Task<object> SaveData()
        {

            return await _db.SaveChangesAsync();
        }

        //Search and Paging

        public async Task<object> pageCount(int pageSize)
        {
            int pageCount = logs.Count();
            int pages = pageCount / pageSize;
            ViewBag.pageCount = pages;
            int rest = pageCount % pageSize;
            if (rest < 10)
            {
                pages = pages + 1;
                ViewBag.pageCount = pages;
            }
            return ViewBag.pageCount;
        }

        //Get IPagedList for View

        public async Task<IPagedList<LogModels>> pagedLogList(int? page)
        {
            logs = await allLogs();
            return logs.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }

        //Get IPagedList for Search
        public async Task<IPagedList<LogModels>> logSearch(int? page, string searchString)
        {
            logs = await allLogs();
            logs = logs.Where(s => s.Description.Contains(searchString)).ToList();
            return logs.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }

        public async Task<IPagedList<LogModels>> pagedLaptopLog(int? page)
        {
            logs = await logLaptop();
            return logs.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }

        public async Task<IPagedList<LogModels>> pagedStoreLog(int? page)
        {
            logs = await logStore();
            return logs.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }

        public async Task<IPagedList<LogModels>> pagedTransferLog(int? page)
        {
            logs = await logTransfer();
            return logs.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }

        public async Task<IPagedList<LogModels>> pagedSearchLog(int? page)
        {
            logs = await logSearch();
            return logs.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }


             public async Task<IPagedList<LogModels>> pagedSearchNotFoundLog(int? page)
        {
            logs = await logSearchNotFound();
            return logs.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }


        public async Task<IPagedList<LogModels>> pagedNewUserLog(int? page)
        {
            logs = await logNewUser();
            return logs.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }


        public async Task<IPagedList<LogModels>> pagedAdminLog(int? page)
        {
            logs = await logAdmin();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            return logs.ToPagedList(pageNumber, pageSize);

        }

        public async Task<IPagedList<LogModels>> pagedAccessLog(int? page)
        {
            logs = await logAccess();
            return logs.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }
    }
}