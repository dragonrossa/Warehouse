using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface IProcessorRepository
    {
        //Get context
        WarehouseContext Data(WarehouseContext _db);
        //One processor
        ProcessorModels processorsList();
        // List with all processors
        List<ProcessorModels> AllProcessors();
        //Save data
        object SaveData();
    }
}