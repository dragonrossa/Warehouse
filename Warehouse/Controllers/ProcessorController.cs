using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class ProcessorController : Controller
    {
        //Get Proccessor Repository
        ProcessorRepository processorRepository = new ProcessorRepository();

        //Processor object

        ProcessorModels processor1 = new ProcessorModels();


        // GET: Proccessor
        public ActionResult Index()
        {

            var list = processorRepository.processorsList();

            return View(list);
        }

        public ActionResult List()
        {

            return View(processorRepository.AllProcessors());
        }

        //using interface
        public ActionResult List2()
        {

            return View(processor1.Child);
        }

        public ActionResult Ascending()
        {
            return View(processor1.Ascending);
        }

        public ActionResult Descending()
        {
            return View(processor1.Descending);
        }
    }
}