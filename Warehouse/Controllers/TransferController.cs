using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Helpers;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class TransferController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Index
        public ActionResult Index()
        {
          

            List<LaptopModels> ListLaptop = (from k in _db.LaptopModels select k).ToList();
      

            var results = (from t in _db.TransferModels
                           join s in _db.StoreModels on t.StoreID equals s.ID
                           select new { s.Name, t.LaptopName, t.LaptopQuantity }).ToList();

            TransferIndex result = new TransferIndex();
            List<TransferIndex> index = new List<TransferIndex>();
            
            foreach(var res in results)
            {
                var LaptopName = res.LaptopName;
                var LaptopQuantity = res.LaptopQuantity;
                var StoreName = res.Name;

                index.Add(new TransferIndex() { LaptopName = LaptopName, LaptopQuantity = LaptopQuantity, StoreName = StoreName });
            }


            //var query = (from t in _db.TransferModels
            //             join s in _db.StoreModels on t.StoreID equals s.ID
            //            select s.Name).ToList();

            //ViewData["storeList"] = (from t in _db.TransferModels
            //                         join s in _db.StoreModels on t.StoreID equals s.ID
            //                         select s.Name).ToList();
            //ViewData["storeList2"] = (from t in _db.TransferModels
            //                         join s in _db.StoreModels on t.StoreID equals s.ID
            //                         select t.LaptopName).ToList();
            //ViewData["storeList3"] = (from t in _db.TransferModels
            //                          join s in _db.StoreModels on t.StoreID equals s.ID
            //                          select t.LaptopQuantity.ToString()).ToList();

            //var query2 = (from t in _db.TransferModels
            //            join s in _db.StoreModels on t.StoreID equals s.ID
            //            select new { s.Name, t.LaptopName, t.LaptopQuantity }).ToList();

   
            return View(index);
        }

        public ActionResult Create()
        {
            ViewData["StoreName"] = _db.StoreModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();

            ViewData["LaptopName"] = _db.LaptopModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();


            //int id = ViewBag.LaptopName[2].Value;
   
            //ViewBag.quantity = (from k in _db.LaptopModels 
            //                       where k.ID==k.ID
            //                    select k.Quantity).First();

            return View();
        }

       
    }
}