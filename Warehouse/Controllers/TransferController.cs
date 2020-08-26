using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class TransferController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: MasterData
        public ActionResult Index()
        {
            //List<TransferModels> listTransfer = (from k in _db.TransferModels select k).ToList();

            //int storeID = (int)Session["storeID"];

            // var store = (from s in _db.StoreModels where s.ID == storeID select s).First();

            // Debug.WriteLine(store.Name);


            var query = (from t in _db.TransferModels
                         join s in _db.StoreModels on t.StoreID equals s.ID
                        select s.Name).ToList();

            ViewData["storeList"] = (from t in _db.TransferModels
                                     join s in _db.StoreModels on t.StoreID equals s.ID
                                     select s.Name).ToList();
            ViewData["storeList2"] = (from t in _db.TransferModels
                                     join s in _db.StoreModels on t.StoreID equals s.ID
                                     select t.LaptopName).ToList();
            ViewData["storeList3"] = (from t in _db.TransferModels
                                      join s in _db.StoreModels on t.StoreID equals s.ID
                                      select t.LaptopQuantity.ToString()).ToList();

            var query2 = (from t in _db.TransferModels
                        join s in _db.StoreModels on t.StoreID equals s.ID
                        select new { s.Name, t.LaptopName, t.LaptopQuantity }).ToList();

           

            //List<TransferModels> list = new List<TransferModels>();

            //list.Add(query2.ToList());

          

            return View();
        }
    }
}