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

        public async Task<ActionResult> AscDate1(int? page) => View("~/Views/Log/Index.cshtml", new LogModels
        {
            logs10 = await logRepository.logLaptop10(page),
            logs20 = await logRepository.logStore20(page),
            logs30 = await logRepository.logTransfer30(page),
            logs40 = await logRepository.logSearch40(page),
            logs50 = await logRepository.logSearchNotFound50(page),
            logs60 = await logRepository.logNewUser60(page),
            logs70 = await logRepository.logAdmin70(page),
            logs80 = await logRepository.logAccess80(page),

        });

        public async Task<ActionResult> DescDate1(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logDescLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)
            });

        }

        //For logs2

        public async Task<ActionResult> AscDate2(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)

            }); ;

        }

        public async Task<ActionResult> DescDate2(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logDescStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)
            });

        }

        //For logs3

        public async Task<ActionResult> AscDate3(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)

            });

        }

        public async Task<ActionResult> DescDate3(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logDescTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)
            });

        }

        //For logs4

        public async Task<ActionResult> AscDate4(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)

            });

        }

        public async Task<ActionResult> DescDate4(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logDescSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)
            });

        }
        //For logs5

        public async Task<ActionResult> AscDate5(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)

            });

        }

        public async Task<ActionResult> DescDate5(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logDescSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)
            });

        }

        //For logs6

        public async Task<ActionResult> AscDate6(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)
            });

        }

        public async Task<ActionResult> DescDate6(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logDescNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)
            });

        }

        //For logs7

        public async Task<ActionResult> AscDate7(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)

            });

        }

        public async Task<ActionResult> DescDate7(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logDescAdmin70(page),
                logs80 = await logRepository.logAccess80(page)
            });

        }

        //For logs8

        public async Task<ActionResult> AscDate8(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logAccess80(page)

            });

        }

        public async Task<ActionResult> DescDate8(int? page)
        {

            return View("~/Views/Log/Index.cshtml", new LogModels
            {
                logs10 = await logRepository.logLaptop10(page),
                logs20 = await logRepository.logStore20(page),
                logs30 = await logRepository.logTransfer30(page),
                logs40 = await logRepository.logSearch40(page),
                logs50 = await logRepository.logSearchNotFound50(page),
                logs60 = await logRepository.logNewUser60(page),
                logs70 = await logRepository.logAdmin70(page),
                logs80 = await logRepository.logDescAccess80(page)
            });

        }

        //For Search - logs

        public async Task<ActionResult> AscDateSearch(int? page)
        {

            return View("~/Views/Log/Search.cshtml", new LogModels
            {
                logs10 = await logRepository.logSearchAsc(Convert.ToString(Session["search"]),page),
            });

        }

        public async Task<ActionResult> DescDateSearch(int? page)
        {

            return View("~/Views/Log/Search.cshtml", new LogModels
            {
                logs10 = await logRepository.logSearchDesc(Convert.ToString(Session["search"]),page),
            });

        }
    }
}