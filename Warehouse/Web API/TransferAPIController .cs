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
    [RoutePrefix("api/transfer")]
    public class TransferAPIController : ApiController
    {
        private WarehouseContext _db = new WarehouseContext();

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

        //Example:
        //api/logAPI/laptopname/Notebook Acer
        [Route("laptopname/{laptopname}")]
        public HttpResponseMessage GetLaptopByName([FromUri] TransferModels transfer)
        {

            string laptopname = transfer.LaptopName;
            if (laptopname == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<TransferModels> transfers = (from k in _db.TransferModels where k.LaptopName == laptopname select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transfers);
            return response;
        }

        //Example:
        //api/logAPI/quantity/5
        [Route("laptopquantity/{laptopquantity}")]
        public HttpResponseMessage GetLaptopByQuantity([FromUri] TransferModels transfer)
        {

            int? laptopquantity = transfer.LaptopQuantity;
            if (laptopquantity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<TransferModels> transfers = (from k in _db.TransferModels where k.LaptopQuantity == laptopquantity select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transfers);
            return response;
        }

        //Example:
        //api/logAPI/store/5
        [Route("store/{storeid}")]
        public HttpResponseMessage GetStoreByID([FromUri] TransferModels transfer)
        {

            int? store = transfer.StoreID;
            if (store == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<StoreModels> transfers = (from k in _db.StoreModels where k.ID == store select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transfers);
            return response;
        }

        //Example:
        //api/logAPI/laptopid/5
        [Route("laptopid/{laptopid}")]
        public HttpResponseMessage GetLaptopByID([FromUri] TransferModels transfer)
        {

            int? laptopid = transfer.LaptopID;

            if (laptopid == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }

            List<TransferModels> transfers = (from k in _db.TransferModels where k.LaptopID == laptopid select k).ToList();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transfers);
            return response;
        }

    }
}
