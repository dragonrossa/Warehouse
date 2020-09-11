using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class TransferAPIController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [HttpGet]
        public IEnumerable<TransferModels> CatchTransfer()
        {
            TransferModels[] transfers = (from k in _db.TransferModels select k).ToArray();
            return transfers;
        }

        [HttpGet]

        public IHttpActionResult GetTransfer(int id)
        {
            
            var transfer = CatchTransfer().FirstOrDefault((p) => p.ID == id);
            if (transfer == null)
            {
                return NotFound();
            }
            return Ok(transfer);
        }


    }
}
