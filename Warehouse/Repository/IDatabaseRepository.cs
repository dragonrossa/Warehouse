using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface IDatabaseRepository
    {
        //Get context
        ApplicationDbContext Data(ApplicationDbContext _db);
 
        //Save data
        object SaveData();
    }
}