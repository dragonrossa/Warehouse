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
    public class OrderByUserController : Controller
    {
        //  UserModels  user = new UserModels();

        UserRepository userRepository = new UserRepository();

        //User - Index - Name, LastName, Username

        public async Task<ActionResult> AscName(int? page)
        {

            return View("~/Views/Admin/Index.cshtml", new UserModels { userAccess = await userRepository.AscendingByName(page) });

        }

        public async Task<ActionResult> DescName(int? page)
        {
            return View("~/Views/Admin/Index.cshtml", new UserModels { userAccess = await userRepository.DescendingByName(page) });

        }

        public async Task<ActionResult> AscLastName(int? page)
        {

            return View("~/Views/Admin/Index.cshtml", new UserModels { userAccess = await userRepository.AscendingByLastName(page) });

        }

        public async Task<ActionResult> DescLastName(int? page)
        {
            return View("~/Views/Admin/Index.cshtml", new UserModels { userAccess = await userRepository.DescendingByLastName(page) });

        }

        public async Task<ActionResult> AscUsername(int? page)
        {

            return View("~/Views/Admin/Index.cshtml", new UserModels { userAccess = await userRepository.AscendingByUserName(page) });

        }

        public async Task<ActionResult> DescUsername(int? page)
        {
            return View("~/Views/Admin/Index.cshtml", new UserModels { userAccess = await userRepository.DescendingByUserName(page) });

        }
    }
}