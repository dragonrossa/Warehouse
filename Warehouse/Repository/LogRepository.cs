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

        //Get log list for every type
        public LogModels logsList()
        {
            // Logs for Laptop

            List<LogModels> log = (from k in _db.LogModels where k.Type == "0" select k)
                                             .OrderBy(x => x.ID)
                                             .ToList();
            //Logs for Store
            List<LogModels> log1 = (from k in _db.LogModels where k.Type == "1" select k)
                                             .OrderBy(x => x.ID)
                                             .ToList();
            //Logs for Transfer
            List<LogModels> log2 = (from k in _db.LogModels where k.Type == "2" select k)
                                            .OrderBy(x => x.ID)
                                            .ToList();
            //Logs for Search
            List<LogModels> log3 = (from k in _db.LogModels where k.Type == "3" select k)
                                        .OrderBy(x => x.ID)
                                        .ToList();
            //Logs for Search - not found
            List<LogModels> log4 = (from k in _db.LogModels where k.Type == "4" select k)
                                       .OrderBy(x => x.ID)
                                       .ToList();
            //Logs for New user
            List<LogModels> log5 = (from k in _db.LogModels where k.Type == "5" select k)
                                      .OrderBy(x => x.ID)
                                      .ToList();

            //Logs for Admin console
            List<LogModels> log6 = (from k in _db.LogModels where k.Type == "6" select k)
                                      .OrderBy(x => x.ID)
                                      .ToList();

            //Logs for Access console
            List<LogModels> log7 = (from k in _db.LogModels where k.Type == "7" select k)
                                      .OrderBy(x => x.ID)
                                      .ToList();

            return new LogModels() { log = log, log1 = log1, log2 = log2, log3 = log3, log4 = log4, log5 = log5, log6 = log6, log7 = log7 };
        }

        //Save DB
        public object SaveData()
        {

            return _db.SaveChanges();
        }

    }
}