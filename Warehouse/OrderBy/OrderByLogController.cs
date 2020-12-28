using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Repository;
using System.Data.Entity;

namespace Warehouse.OrderBy
{
    public class OrderByLogController : Controller
    {

        //Get logRepository object

        LogRepository logRepository = new LogRepository();
       
        //For logs1

        public async Task<ActionResult> AscDate1()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels  { 
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()

            });

        }

        public async Task<ActionResult> DescDate1()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels { 
                logs1 = await logRepository.logDescLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()
            });

        }

        //For logs2

        public async Task<ActionResult> AscDate2()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()

            }); ;

        }

        public async Task<ActionResult> DescDate2()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logDescStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()
            });

        }

        //For logs3

        public async Task<ActionResult> AscDate3()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()

            });

        }

        public async Task<ActionResult> DescDate3()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logDescTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()
            });

        }

        //For logs4

        public async Task<ActionResult> AscDate4()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()

            });

        }

        public async Task<ActionResult> DescDate4()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logDescSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()
            });

        }
        //For logs5

        public async Task<ActionResult> AscDate5()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()

            });

        }

        public async Task<ActionResult> DescDate5()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logDescSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()
            });

        }

        //For logs6

        public async Task<ActionResult> AscDate6()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()

            });

        }

        public async Task<ActionResult> DescDate6()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logDescNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()
            });

        }

        //For logs7

        public async Task<ActionResult> AscDate7()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()

            });

        }

        public async Task<ActionResult> DescDate7()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logDescAdmin(),
                logs8 = await logRepository.logAccess()
            });

        }

        //For logs8

        public async Task<ActionResult> AscDate8()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logAccess()

            });

        }

        public async Task<ActionResult> DescDate8()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = await logRepository.logLaptop(),
                logs2 = await logRepository.logStore(),
                logs3 = await logRepository.logTransfer(),
                logs4 = await logRepository.logSearch(),
                logs5 = await logRepository.logSearchNotFound(),
                logs6 = await logRepository.logNewUser(),
                logs7 = await logRepository.logAdmin(),
                logs8 = await logRepository.logDescAccess()
            });

        }

        //For logs8

        public async Task<ActionResult> AscDateSearch()
        {

            return View("~/Views/Log/Search.cshtml", new LogModels
            {
                logs1 = await logRepository.logSearchAsc(Convert.ToString(TempData["search"])),
            });

        }

        public async Task<ActionResult> DescDateSearch()
        {

            return View("~/Views/Log/Search.cshtml", new LogModels
            {
                logs1 = await logRepository.logSearchDesc(Convert.ToString(TempData["search"])),
            });

        }
    }
}