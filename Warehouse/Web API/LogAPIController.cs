﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    [RoutePrefix("api/log")]
    public class LogAPIController : ApiController
    {
        
        private WarehouseContext _db = new WarehouseContext();

        [HttpGet]
        public IEnumerable<LogModels> CatchLogs()
        {
            LogModels[] logs = (from k in _db.LogModels select k).ToArray();
            return logs;
        }

        [HttpGet]

        public IHttpActionResult GetLogs(int id)
        {
            
            var log = CatchLogs().FirstOrDefault((p) => p.ID == id);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }

    }
}
