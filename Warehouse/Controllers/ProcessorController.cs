using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class ProcessorController : Controller
    {


        private ApplicationDbContext _db = new ApplicationDbContext();

        private ProcessorModels _processor;

        private List<ProcessorModels> _proc;

        public ProcessorModels processorsList
        {
            get
            {
                return _processor = (from l in _db.ProccessorModels where l.ID==1 select l).FirstOrDefault();
            }
            private set
            {
                _processor = value;
            }
        }

        public List<ProcessorModels> AllProcessors
        {
            get
            {
                _proc = (from l in _db.ProccessorModels select l).ToList();
                return _proc;
                //return AllProcessors;
            }
            private set
            {
                _proc = value;
            }
        }


        // GET: Proccessor
        public ActionResult Index()
        {

            var list = processorsList;

            return View(list);
        }

        public ActionResult List()
        {

            return View(AllProcessors);
        }

        public ActionResult List2()
        {

            ProcessorModels processor = new ProcessorModels();

            List<ProcessorModels> listOfProcessors = processor.Child;
                

            Debug.WriteLine(listOfProcessors);


            return View(listOfProcessors);
        }
    }
}