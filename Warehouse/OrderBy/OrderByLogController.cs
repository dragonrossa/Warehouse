using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.OrderBy
{
    public class OrderByLogController : Controller
    {
        LogModels log = new LogModels();

        LogRepository logRepository = new LogRepository();

        //For logs1

        public ActionResult AscDate1()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels  { 
                logs1 = log.AscendingByDate,
                logs2 = logRepository.logStore(),
                logs3 = logRepository.logTransfer(),
                logs4 = logRepository.logSearch(),
                logs5 = logRepository.logSearchNotFound(),
                logs6 = logRepository.logNewUser(),
                logs7 = logRepository.logAdmin(),
                logs8 = logRepository.logAccess()

            });

        }

        public ActionResult DescDate1()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels { 
                logs1 = log.DescendingByDate,
                logs2 = logRepository.logStore(),
                logs3 = logRepository.logTransfer(),
                logs4 = logRepository.logSearch(),
                logs5 = logRepository.logSearchNotFound(),
                logs6 = logRepository.logNewUser(),
                logs7 = logRepository.logAdmin(),
                logs8 = logRepository.logAccess()
            });

        }

        //For logs2

        public ActionResult AscDate2()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = log.AscendingByDate,
                logs3 = logRepository.logTransfer(),
                logs4 = logRepository.logSearch(),
                logs5 = logRepository.logSearchNotFound(),
                logs6 = logRepository.logNewUser(),
                logs7 = logRepository.logAdmin(),
                logs8 = logRepository.logAccess()

            }); ;

        }

        public ActionResult DescDate2()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = log.DescendingByDate,
                logs3 = logRepository.logTransfer(),
                logs4 = logRepository.logSearch(),
                logs5 = logRepository.logSearchNotFound(),
                logs6 = logRepository.logNewUser(),
                logs7 = logRepository.logAdmin(),
                logs8 = logRepository.logAccess()
            });

        }

        //For logs3

        public ActionResult AscDate3()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = logRepository.logStore(),
                logs3 = log.AscendingByDate,
                logs4 = logRepository.logSearch(),
                logs5 = logRepository.logSearchNotFound(),
                logs6 = logRepository.logNewUser(),
                logs7 = logRepository.logAdmin(),
                logs8 = logRepository.logAccess()

            });

        }

        public ActionResult DescDate3()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = logRepository.logStore(),
                logs3 = log.DescendingByDate,
                logs4 = logRepository.logSearch(),
                logs5 = logRepository.logSearchNotFound(),
                logs6 = logRepository.logNewUser(),
                logs7 = logRepository.logAdmin(),
                logs8 = logRepository.logAccess()
            });

        }

        //For logs4

        public ActionResult AscDate4()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = logRepository.logStore(),
                logs3 = logRepository.logTransfer(),
                logs4 = log.AscendingByDate,
                logs5 = logRepository.logSearchNotFound(),
                logs6 = logRepository.logNewUser(),
                logs7 = logRepository.logAdmin(),
                logs8 = logRepository.logAccess()

            });

        }

        public ActionResult DescDate4()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = logRepository.logStore(),
                logs3 = logRepository.logTransfer(),
                logs4 = log.DescendingByDate,
                logs5 = logRepository.logSearchNotFound(),
                logs6 = logRepository.logNewUser(),
                logs7 = logRepository.logAdmin(),
                logs8 = logRepository.logAccess()
            });

        }
        //For logs5

        public ActionResult AscDate5()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = logRepository.logStore(),
                logs3 = logRepository.logTransfer(),
                logs4 = logRepository.logSearch(),
                logs5 = log.AscendingByDate,
                logs6 = logRepository.logNewUser(),
                logs7 = logRepository.logAdmin(),
                logs8 = logRepository.logAccess()

            });

        }

        public ActionResult DescDate5()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = logRepository.logStore(),
                logs3 = logRepository.logTransfer(),
                logs4 = logRepository.logSearch(),
                logs5 = log.DescendingByDate,
                logs6 = logRepository.logNewUser(),
                logs7 = logRepository.logAdmin(),
                logs8 = logRepository.logAccess()
            });

        }

        //For logs6

        public ActionResult AscDate6()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = logRepository.logStore(),
                logs3 = logRepository.logTransfer(),
                logs4 = logRepository.logSearch(),
                logs5 = logRepository.logSearchNotFound(),
                logs6 = log.AscendingByDate,
                logs7 = logRepository.logAdmin(),
                logs8 = logRepository.logAccess()

            });

        }

        public ActionResult DescDate6()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = logRepository.logStore(),
                logs3 = logRepository.logTransfer(),
                logs4 = logRepository.logSearch(),
                logs5 = logRepository.logSearchNotFound(),
                logs6 = log.DescendingByDate,
                logs7 = logRepository.logAdmin(),
                logs8 = logRepository.logAccess()
            });

        }

        //For logs7

        public ActionResult AscDate7()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = logRepository.logStore(),
                logs3 = logRepository.logTransfer(),
                logs4 = logRepository.logSearch(),
                logs5 = logRepository.logSearchNotFound(),
                logs6 = logRepository.logNewUser(),
                logs7 = log.AscendingByDate,
                logs8 = logRepository.logAccess()

            });

        }

        public ActionResult DescDate7()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = logRepository.logStore(),
                logs3 = logRepository.logTransfer(),
                logs4 = logRepository.logSearch(),
                logs5 = logRepository.logSearchNotFound(),
                logs6 = logRepository.logNewUser(),
                logs7 = log.DescendingByDate,
                logs8 = logRepository.logAccess()
            });

        }

        //For logs8

        public ActionResult AscDate8()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = logRepository.logStore(),
                logs3 = logRepository.logTransfer(),
                logs4 = logRepository.logSearch(),
                logs5 = logRepository.logSearchNotFound(),
                logs6 = logRepository.logNewUser(),
                logs7 = log.AscendingByDate,
                logs8 = logRepository.logAccess()

            });

        }

        public ActionResult DescDate8()
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs1 = logRepository.logLaptop(),
                logs2 = logRepository.logStore(),
                logs3 = logRepository.logTransfer(),
                logs4 = logRepository.logSearch(),
                logs5 = logRepository.logSearchNotFound(),
                logs6 = logRepository.logNewUser(),
                logs7 = logRepository.logAdmin(),
                logs8 = log.DescendingByDate
            });

        }
    }
}