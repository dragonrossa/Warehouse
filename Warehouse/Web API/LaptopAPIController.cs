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
    [RoutePrefix("api/laptop")]
    public class LaptopAPIController : ApiController
    {
        private WarehouseContext _db = new WarehouseContext();

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

        //Example:
        //api/laptopAPI/name/Notebook Acer
        [Route("name/{name}")]
        public HttpResponseMessage GetLaptopByName([FromUri] LaptopModels laptop)
        {

            string name = laptop.Name;
            if (name == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<LaptopModels> laptops = (from k in _db.LaptopModels where k.Name == name select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, laptops);
            return response;
        }

        //Example:
        //api/laptopAPI/quantity/5
        [Route("quantity/{quantity}")]
        public HttpResponseMessage GetLaptopByQuantity([FromUri] LaptopModels laptop)
        {

            int? quantity = laptop.Quantity;
            if (quantity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<LaptopModels> laptops = (from k in _db.LaptopModels where k.Quantity == quantity select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, laptops);
            return response;
        }

       
        //Example:
        //api/laptopAPI/manufacturer/HP
        [Route("manufacturer/{manufacturer}")]
        public HttpResponseMessage GetLaptopByManufacturer([FromUri] LaptopModels laptop)
        {

            string manufacturer = laptop.Manufacturer;
            if (manufacturer == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<LaptopModels> laptops = (from k in _db.LaptopModels where k.Manufacturer == manufacturer select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, laptops);
            return response;
        }

        //Example:
        //api/laptopAPI/sn/123456789
        [Route("sn/{sn}")]
        public HttpResponseMessage GetLaptopBySN([FromUri] LaptopModels laptop)
        {

            string sn = laptop.SN;
            if (sn == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<LaptopModels> laptops = (from k in _db.LaptopModels where k.SN == sn select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, laptops);
            return response;
        }

        //Example:
        //api/laptopAPI/os/Linux
        [Route("os/{os}")]
        public HttpResponseMessage GetLaptopByOS([FromUri] LaptopModels laptop)
        {

            string os = laptop.OS;
            if (os == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<LaptopModels> laptops = (from k in _db.LaptopModels where k.OS == os select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, laptops);
            return response;
        }
    }
}
