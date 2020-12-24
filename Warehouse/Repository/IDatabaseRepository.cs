using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface IDatabaseRepository
    {
        //Get context
        WarehouseContext Data(WarehouseContext _db);

        //Add to database
       // void addToDatabase(TransferModels transfer);
   
        //Save data
        object SaveData();
    }
}