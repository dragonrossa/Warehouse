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
        LogModels logsList();
        //Save data
        object SaveData();
    }
}