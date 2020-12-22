using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        //Get suppliers for Asc and Desc
        public async Task<List<SelectListItem>> supplier()
        {
            return await computerRepository.suppliers();
        }


        //ComputerList - Name

        public async Task<ActionResult> AscName()
        {
            return View("~/Views/ComputerList/Index.cshtml", new ComputerListModels { computersList = computer.AscendingByName,
                suppliers = await supplier()
            });

        }

        public async Task<ActionResult> DescName()
        {
            return View("~/Views/ComputerList/Index.cshtml", new ComputerListModels { computersList = computer.DescendingByName,
                suppliers = await supplier()
            });

        }
    }
}