using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class ProcessorRepository:IProcessorRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private ProcessorModels _processor;

        private List<ProcessorModels> _proc;



        //Get DB
        public ApplicationDbContext Data(ApplicationDbContext _db)
        {

            this._db = _db;
            return _db;
        }

        //One processor

        public ProcessorModels processorsList()
        {
           
                return _processor = (from l in _db.ProccessorModels where l.ID == 1 select l).FirstOrDefault();
            
        }

        // List with all processors
        public List<ProcessorModels> AllProcessors()
        {
            
                _proc = (from l in _db.ProccessorModels select l).ToList();
                return _proc;

        }



        //Save DB
        public object SaveData()
        {

            return _db.SaveChanges();
        }

    }
}