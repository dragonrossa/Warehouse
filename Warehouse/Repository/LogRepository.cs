using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Warehouse.Models;
using System.Data.Entity;
using Warehouse.DAL;

namespace Warehouse.Repository
{
    public class LogRepository : ILogRepository
    {
        private WarehouseContext _db = new WarehouseContext();

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

        //desc

        public async Task<List<LogModels>> logDescLaptop()
        {
            return await (from k in _db.LogModels where k.Type == "0" select k)
                                              .OrderByDescending(x => x.ID)
                                              .ToListAsync();
        }

        //2 - asc

        public async Task<List<LogModels>> logStore()
        {
            return await (from k in _db.LogModels where k.Type == "1" select k)
                                             .OrderBy(x => x.ID)
                                             .ToListAsync();
        }

        //desc

        public async Task<List<LogModels>> logDescStore()
        {
            return await (from k in _db.LogModels where k.Type == "1" select k)
                                             .OrderByDescending(x => x.ID)
                                             .ToListAsync();
        }

        //3 - asc

        public async Task<List<LogModels>> logTransfer()
        {
            return await (from k in _db.LogModels where k.Type == "2" select k)
                                            .OrderBy(x => x.ID)
                                            .ToListAsync();
        }

        //desc

        public async Task<List<LogModels>> logDescTransfer()
        {
            return await (from k in _db.LogModels where k.Type == "2" select k)
                                            .OrderByDescending(x => x.ID)
                                            .ToListAsync();
        }

        //4 - asc

        public async Task<List<LogModels>> logSearch()
        {
            return await (from k in _db.LogModels where k.Type == "3" select k)
                                        .OrderBy(x => x.ID)
                                        .ToListAsync();
        }

        //desc 
        public async Task<List<LogModels>> logDescSearch()
        {
            return await (from k in _db.LogModels where k.Type == "3" select k)
                                        .OrderByDescending(x => x.ID)
                                        .ToListAsync();
        }

        //5 - asc

        public async Task<List<LogModels>> logSearchNotFound()
        {
            return await (from k in _db.LogModels where k.Type == "4" select k)
                                       .OrderBy(x => x.ID)
                                       .ToListAsync();
        }

        //desc
        public async Task<List<LogModels>> logDescSearchNotFound()
        {
            return await (from k in _db.LogModels where k.Type == "4" select k)
                                       .OrderBy(x => x.ID)
                                       .ToListAsync();
        }

        //6 - asc

        public async Task<List<LogModels>> logNewUser()
        {
            return await (from k in _db.LogModels where k.Type == "5" select k)
                                      .OrderBy(x => x.ID)
                                      .ToListAsync();
        }

        //desc

        public async Task<List<LogModels>> logDescNewUser()
        {
            return await (from k in _db.LogModels where k.Type == "5" select k)
                                      .OrderByDescending(x => x.ID)
                                      .ToListAsync();
        }

        //7 - asc

        public async Task<List<LogModels>> logAdmin()
        {
            return await (from k in _db.LogModels where k.Type == "6" select k)
                                      .OrderBy(x => x.ID)
                                      .ToListAsync();
        }

        //desc
        public async Task<List<LogModels>> logDescAdmin()
        {
            return await (from k in _db.LogModels where k.Type == "6" select k)
                                      .OrderByDescending(x => x.ID)
                                      .ToListAsync();
        }

        //8 - asc

        public async Task<List<LogModels>> logAccess()
        {
            return await (from k in _db.LogModels where k.Type == "7" select k)
                                      .OrderBy(x => x.ID)
                                      .ToListAsync();
        }


        //desc
        public async Task<List<LogModels>> logDescAccess()
        {
            return await (from k in _db.LogModels where k.Type == "7" select k)
                                      .OrderByDescending(x => x.ID)
                                      .ToListAsync();
        }

        //asc

        public async Task<List<LogModels>> logSearchAsc(string searchString)
        {
            return await _db.LogModels
                .OrderBy(s => s.Date)
                .Where(s => s.Description.Contains(searchString)).ToListAsync();
        }

        //desc
        public async Task<List<LogModels>> logSearchDesc(string searchString)
        {
           
           return await _db.LogModels
                .OrderByDescending(s=>s.Date)
                .Where(s => s.Description.Contains(searchString)).ToListAsync();
        }


        //Save DB
        public async Task<object> SaveData()
        {

            return await _db.SaveChangesAsync();
        }

    }
}