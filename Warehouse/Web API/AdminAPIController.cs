using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using Warehouse.Helpers;
using Warehouse.Models;

namespace Warehouse.Web_API
{
    [RoutePrefix("api/admin")]
    public class AdminAPIController : ApiController
    {

        HelperAdmin helper = new HelperAdmin();

        public List<AdminModels> adminList1()
        {
           // adminList = helper.Child;
            return helper.List;

        }
  

        [HttpGet]
        public List<AdminModels> CatchNotebooks()
        {
            return adminList1();
        }


        //Example
        //https://localhost:44336/api/adminAPI/6

        [HttpGet]
        public IHttpActionResult GetNotebook(int id)
        {

            var adminlist = CatchNotebooks().FirstOrDefault((p) => p.ID == id);


            if (adminlist == null)
            {
                return NotFound();
            }
            return Ok(adminlist);
        }

        //Example
        //https://localhost:44336/api/adminAPI/?username=rodjuga@gmail.com

        [HttpGet]
        public IHttpActionResult GetNotebook(string username)
        {

            var adminlist = CatchNotebooks().FirstOrDefault((p) => p.Username == username);

            if (adminlist == null)
            {
                return NotFound();
            }
            return Ok(adminlist);
        }


        //Example
        //https://localhost:44336/api/adminAPI/?roleid=39

        [HttpGet]
        public IHttpActionResult GetNotebookbyRoleID(int roleid)
        {

            var adminlist = CatchNotebooks().FirstOrDefault((p) => p.RoleID == roleid);

            if (adminlist == null)
            {
                return NotFound();
            }
            return Ok(adminlist);
        }


    }
}