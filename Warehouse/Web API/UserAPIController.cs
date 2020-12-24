using Microsoft.Ajax.Utilities;
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
    [RoutePrefix("api/user")]
    public class UserAPIController : ApiController
    {
        private WarehouseContext _db = new WarehouseContext();

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

        //Example:
        //api/logAPI/name/Rosana
        [Route("name/{name}")]
        public HttpResponseMessage GetUserByName([FromUri] UserModels user)
        {

            string name = user.Name;
            if (name == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<UserModels> users = (from k in _db.UserModels where k.Name == name select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, users);

            return response;
        }

        //Example:
        //api/logAPI/lastname/Đuga
        [Route("lastname/{lastname}")]
        public HttpResponseMessage GetUserByLastName([FromUri] UserModels user)
        {

            string lastname = user.LastName;
            if (lastname == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<UserModels> users = (from k in _db.UserModels where k.LastName == lastname select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, users);

            return response;
        }

        //Example:
        //api/logAPI/address/Test
        [Route("address/{address}")]
        public HttpResponseMessage GetUserByAddress([FromUri] UserModels user)
        {

            string address = user.Address;
            if (address == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<UserModels> users = (from k in _db.UserModels where k.Address == address select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, users);

            return response;
        }

        //Example:
        //api/logAPI/zipcode/10000
        [Route("zipcode/{zipcode}")]
        public HttpResponseMessage GetUserByZipCode([FromUri] UserModels user)
        {

            string zipcode = user.ZipCode;
            if (zipcode == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<UserModels> users = (from k in _db.UserModels where k.ZipCode == zipcode select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, users);

            return response;
        }

        //Example:
        //api/logAPI/country/Croatia
        [Route("country/{country}")]
        public HttpResponseMessage GetUserByCountry([FromUri] UserModels user)
        {

            string country = user.Country;
            if (country == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<UserModels> users = (from k in _db.UserModels where k.Country == country select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, users);

            return response;
        }

        //Example:
        //api/logAPI/mail/rodjuga@gmail.com/
        [Route("mail/{mail}")]
        public HttpResponseMessage GetUserByEmail([FromUri] UserModels user)
        {

            string mail = user.Mail;
            if (mail == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<UserModels> users = (from k in _db.UserModels where k.Mail == mail select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, users);

            return response;
        }

        //Example:
        //api/logAPI/telephone/01010101
        [Route("telephone/{telephone}")]
        public HttpResponseMessage GetUserByTelephone([FromUri] UserModels user)
        {

            string telephone = user.Telephone;
            if (telephone == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<UserModels> users = (from k in _db.UserModels where k.Telephone == telephone select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, users);

            return response;
        }

        //Example:
        //api/logAPI/username/rodjuga@gmail.com/
        [Route("username/{username}")]
        public HttpResponseMessage GetUserByUserName([FromUri] UserModels user)
        {

            string username = user.UserName;
            if (username == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<UserModels> users = (from k in _db.UserModels where k.UserName == username select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, users);

            return response;
        }

        //Example:
        //api/logAPI/hometown/Zagreb
        [Route("hometown/{hometown}")]
        public HttpResponseMessage GetUserByHometown([FromUri] UserModels user)
        {

            string hometown = user.Hometown;
            if (hometown == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<UserModels> users = (from k in _db.UserModels where k.Hometown == hometown select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, users);

            return response;
        }



    }
}
