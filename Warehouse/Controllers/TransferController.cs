using Microsoft.AspNet.Identity;
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
            var user = User.Identity.GetUserName();

            bool access = (from a in _db.AdminModels where a.Username == user select a.TransferAccess).FirstOrDefault();

            bool fal = false;

            if (access == fal)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return RedirectToAction("Index", "Laptop");
            }
            else
            {

                try
                {
                    List<LaptopModels> ListLaptop = (from k in _db.LaptopModels select k).ToList();


                    var results = (from t in _db.TransferModels
                                   join s in _db.StoreModels on t.StoreID equals s.ID
                                   select new { s.Name, t.LaptopName, t.LaptopQuantity }).ToList();

                    TransferIndex result = new TransferIndex();
                    List<TransferIndex> index = new List<TransferIndex>();

                    foreach (var res in results)
                    {
                        var LaptopName = res.LaptopName;
                        var LaptopQuantity = res.LaptopQuantity;
                        var StoreName = res.Name;

                        index.Add(new TransferIndex() { LaptopName = LaptopName, LaptopQuantity = LaptopQuantity, StoreName = StoreName });
                    }


                    var lastInput = (from k in _db.TransferModels
                                     select k)
                               .OrderByDescending(k => k.ID)
                               .First();

                    ViewBag.laptop = lastInput.LaptopName;
                    ViewBag.date = lastInput.Date;
                    ViewBag.quantity = lastInput.LaptopQuantity;


                    return View(index);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }

                return View();
            }
        }

        public ActionResult Create()
        {
            try
            {
                ViewData["StoreName"] = _db.StoreModels.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString()
                }).ToList();

                ViewData["LaptopName"] = _db.LaptopModels.Where(u => u.Quantity != 0).ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString()
                }).ToList();


                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
           
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]

        public ActionResult Create(FormCollection form, TransferModels transfer)
        {
            try
            {

                int storeID = Convert.ToInt32(form["StoreName"].ToString());
                int LaptopID = Convert.ToInt32(form["LaptopName"].ToString());
                int LaptopQuantity = Convert.ToInt32(form["LaptopQuantity"].ToString());

                var possibleCount = (from k in _db.LaptopModels where k.ID == LaptopID select k.Quantity).First();

                if (possibleCount > 0)
                {

                    var laptop = (from k in _db.LaptopModels where k.ID == LaptopID select k.Name).First();
                    transfer.StoreID = storeID;
                    transfer.LaptopID = LaptopID;
                    transfer.LaptopName = laptop;
                    transfer.LaptopQuantity = LaptopQuantity;
                    transfer.Date = DateTime.Now;// add if any field you want insert
                    _db.TransferModels.Add(transfer);
                    _db.SaveChanges();
                    //get Laptop
                    var storeFind = (from s in _db.StoreModels where s.ID == storeID select s).First(); //select store, change Qop
                    storeFind.QoP = storeFind.QoP - LaptopQuantity; // reduce QoP for quantity number
                    _db.SaveChanges();
                    var laptopFind = (from k in _db.LaptopModels where k.ID == transfer.LaptopID select k).First(); //select laptop
                    laptopFind.Quantity = laptopFind.Quantity - LaptopQuantity;  // reduce LaptopQuantity from Quantity
                    _db.SaveChanges();


                    //Create new log
                    LogModels log = new LogModels
                    {
                        Type = "2",
                        Description = "New transfer was inserted with transfer of laptop called " + transfer.LaptopName + " with quantity of " +
                            transfer.LaptopQuantity + " on date " + laptopFind.Date + " with location to " + storeFind.Name + ", " + storeFind.Location + ".",
                        Date = laptopFind.Date
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();

                }

                else
                {
                    return RedirectToAction("Index", "Laptop", new { });
                }



                return RedirectToAction("Index", "Transfer", new { });
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

          
        }

       
    }
}