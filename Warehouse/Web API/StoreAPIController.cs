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
    public class StoreAPIController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [HttpGet]
        public IEnumerable<StoreModels> CatchStores()
        {
            StoreModels[] store = (from k in _db.StoreModels select k).ToArray();
            return store;
        }

        [HttpGet]

        public IHttpActionResult GetStore(int id)
        {
            
            var store = CatchStores().FirstOrDefault((p) => p.ID == id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }


    }
}
