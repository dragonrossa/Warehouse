using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class LogRepository : ILogRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //Get DB
        public ApplicationDbContext Data(ApplicationDbContext _db)
        {

            this._db = _db;
            return _db;
        }

        //1

        public List<LogModels> logLaptop()
        {
            return (from k in _db.LogModels where k.Type == "0" select k)
                                              .OrderBy(x => x.ID)
                                              .ToList();
        }

        //2

        public List<LogModels> logStore()
        {
            return (from k in _db.LogModels where k.Type == "1" select k)
                                             .OrderBy(x => x.ID)
                                             .ToList();
        }

        //3

        public List<LogModels> logTransfer()
        {
            return (from k in _db.LogModels where k.Type == "2" select k)
                                            .OrderBy(x => x.ID)
                                            .ToList();
        }

        //4

        public List<LogModels> logSearch()
        {
            return (from k in _db.LogModels where k.Type == "3" select k)
                                        .OrderBy(x => x.ID)
                                        .ToList();
        }

        //5

        public List<LogModels> logSearchNotFound()
        {
            return (from k in _db.LogModels where k.Type == "4" select k)
                                       .OrderBy(x => x.ID)
                                       .ToList();
        }

        //6

        public List<LogModels> logNewUser()
        {
            return (from k in _db.LogModels where k.Type == "5" select k)
                                      .OrderBy(x => x.ID)
                                      .ToList();
        }

        //7

        public List<LogModels> logAdmin()
        {
            return (from k in _db.LogModels where k.Type == "6" select k)
                                      .OrderBy(x => x.ID)
                                      .ToList();
        }

        //8

        public List<LogModels> logAccess()
        {
            return (from k in _db.LogModels where k.Type == "7" select k)
                                      .OrderBy(x => x.ID)
                                      .ToList();
        }

        
        //Save DB
        public object SaveData()
        {

            return _db.SaveChanges();
        }

    }
}