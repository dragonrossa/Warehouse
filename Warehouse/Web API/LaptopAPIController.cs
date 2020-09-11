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
    public class LaptopAPIController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [HttpGet]
        public IEnumerable<LaptopModels> CatchNotebooks()
        {
            LaptopModels[] laptop = (from k in _db.LaptopModels select k).ToArray();
            return laptop;
        }

        [HttpGet]

        public IHttpActionResult GetNotebook(int id)
        {
            
            var laptop = CatchNotebooks().FirstOrDefault((p) => p.ID == id);
            if (laptop == null)
            {
                return NotFound();
            }
            return Ok(laptop);
        }


    }
}
