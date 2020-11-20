using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface IProcessorRepository
    {
        //Get context
        ApplicationDbContext Data(ApplicationDbContext _db);
        //One processor
        ProcessorModels processorsList();
        // List with all processors
        List<ProcessorModels> AllProcessors();
        //Save data
        object SaveData();
    }
}