using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface ILogRepository
    {
        //Get context
        ApplicationDbContext Data(ApplicationDbContext _db);
        //Get log list for every type
        //1
        List<LogModels> logLaptop();
        //2
        List<LogModels> logStore();
        //3
        List<LogModels> logTransfer();
        //4
        List<LogModels> logSearch();
        //5
        List<LogModels> logSearchNotFound();
        //6
        List<LogModels> logNewUser();
        //7
        List<LogModels> logAdmin();
        //8
        List<LogModels> logAccess();
        //Save data
        object SaveData();
    }
}