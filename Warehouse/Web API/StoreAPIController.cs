using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.UI.WebControls;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    [RoutePrefix("api/store")]
    public class StoreAPIController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [HttpGet]
        public IEnumerable<StoreModels> CatchStores()
        {
            StoreModels[] store = (from k in _db.StoreModels select k).ToArray();
            return store;
        }

        //storeAPI/1

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

        //Example:
        //api/storeAPI?id=1&name=a

        [HttpGet]

        public IHttpActionResult GetStore(int id, string name)
        {

            var store = CatchStores().FirstOrDefault((p) => p.Name == name);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        //Example:
        //api/storeAPI/search/SD Store Zadar
        //api/storeAPI/search/a
        [Route("search/{name}")]
        public HttpResponseMessage Get([FromUri] StoreModels store)
        {

            string name = store.Name;
            if (name == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Not found");
            }

            
            var storeSearch = store.Child.FirstOrDefault((p) => p.Name == name);

          // var abcd = store.Ascending;

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, storeSearch);

      
            return response;
        }

        //Example:
        //api/storeAPI/location/Zagreb
        [Route("location/{location}")]
        public HttpResponseMessage GetStoreByLocation([FromUri] StoreModels store)
        {
            

            string name = store.Location;
            if (name == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<StoreModels> stores = (from k in _db.StoreModels where k.Location==name select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, stores);


            return response;
        }

        //Example:
        //api/storeAPI/zipcode/10000
        [Route("zipcode/{zipcode}")]
        public HttpResponseMessage GetStoreByZipCode([FromUri] StoreModels store)
        {

            int? zipCode = store.ZipCode;
            if (zipCode == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<StoreModels> stores = (from k in _db.StoreModels where k.ZipCode == zipCode select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, stores);


            return response;
        }

        //Example:
        //api/storeAPI/address/Užarska 30
        [Route("address/{address}")]
        public HttpResponseMessage GetStoreByAddress([FromUri] StoreModels store)
        {

            string address = store.Address;
            if (address == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<StoreModels> stores = (from k in _db.StoreModels where k.Address == address select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, stores);


            return response;
        }

        //quantity
        [Route("qop/{qop}")]
        public HttpResponseMessage GetStoreByQuantity([FromUri] StoreModels store)
        {

            int? qop = store.QoP;
            if (qop == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<StoreModels> stores = (from k in _db.StoreModels where k.QoP == qop select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, stores);


            return response;
        }

      
        //Example:
        //api/storeAPI/telephone/010101010
        [Route("telephone/{telephone}")]
        public HttpResponseMessage GetStoreByTelephoneNumber([FromUri] StoreModels store)
        {

            string telephone = store.Telephone;
            if (telephone == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<StoreModels> stores = (from k in _db.StoreModels where k.Telephone == telephone select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, stores);


            return response;
        }

        //Example:
        //api/storeAPI/email/zadar@sancta-domenica.hr/ (Dummy info) -> add slash on the end
        [Route("email/{email}")]
        public HttpResponseMessage GetStoreByEmail([FromUri] StoreModels store)
        {

            string email = store.Email;
            if (email == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<StoreModels> stores = (from k in _db.StoreModels where k.Email == email select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, stores);


            return response;
        }



    }
}
