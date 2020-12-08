using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.OrderBy
{
    public class OrderByComputerListController : Controller
    {
        //Get ComputerList object

        ComputerListModels computer = new ComputerListModels();

        //Get ComputerLirstRepository

        ComputerListRepository computerRepository = new ComputerListRepository();


        //ComputerList - Name

        public ActionResult AscName()
        {

            return View("~/Views/ComputerList/Index.cshtml", new ComputerListModels { computersList = computer.AscendingByName,
                suppliers = computerRepository.suppliers()
            });

        }

        public ActionResult DescName()
        {
            return View("~/Views/ComputerList/Index.cshtml", new ComputerListModels { computersList = computer.DescendingByName,
                suppliers = computerRepository.suppliers()
            });

        }
    }
}