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
    public class UserAPIController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [HttpGet]
        public IEnumerable<UserModels> CatchUsers()
        {
            UserModels[] users = (from k in _db.UserModels select k).ToArray();
            return users;
        }

        [HttpGet]

        public IHttpActionResult GetUser(int id)
        {
            
            var user = CatchUsers().FirstOrDefault((p) => p.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


    }
}
