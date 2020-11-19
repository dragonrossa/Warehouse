using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Warehouse.Helpers;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class TransferController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        TransferIndex result = new TransferIndex();

        List<TransferIndex> index = new List<TransferIndex>();

        public List<LaptopModels> ListLaptop()
        {

            return (from k in _db.LaptopModels select k).ToList();
        }

        public object callResult()
        {
            return (from t in _db.TransferModels join s in _db.StoreModels on t.StoreID equals s.ID select new { s.Name, t.LaptopName, t.LaptopQuantity }).ToList();
        }

        public List<SelectListItem> StoreName()
        {
            return _db.StoreModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();
        }

        public List<SelectListItem> LaptopName()
        {
            return _db.LaptopModels.Where(u => u.Quantity != 0).ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();

        }

        public int possibleCount(int LaptopID)
        {
            return (from k in _db.LaptopModels where k.ID == LaptopID select k.Quantity).First();
        }

        public string laptop(int LaptopID)
        {
            return (from k in _db.LaptopModels where k.ID == LaptopID select k.Name).First();
        }

        public StoreModels storeFind(int storeID){
            return (from s in _db.StoreModels where s.ID == storeID select s).First();
         }

        public LaptopModels laptopFind(int TransferLaptopID)
        {
            return (from k in _db.LaptopModels where k.ID == TransferLaptopID select k).First();
        }

        //Custom Exception for UserNotFound

        public class UserNotFoundException : Exception
        {
            public UserNotFoundException() : base() {}
            public UserNotFoundException(string message) : base(message) { }
            public UserNotFoundException(string message, Exception innerException)
                : base(message, innerException) { }
        }


        // GET: Index
        public ActionResult Index()
        {
            var user = User.Identity.GetUserName();

          

                try
                {
               

                    //New list

                    var results = (from t in _db.TransferModels
                                   join s in _db.StoreModels on t.StoreID equals s.ID
                                   select new { s.Name, t.LaptopName, t.LaptopQuantity }).ToList();



                    foreach (var res in results)
                    {
                    
                        index.Add(new TransferIndex() { 
                            LaptopName = res.LaptopName,
                            LaptopQuantity = res.LaptopQuantity, 
                            StoreName = res.Name });
                    }

                TransferModels transfer = new TransferModels();

                ViewBag.laptop = transfer.lastInput.LaptopName;
                ViewBag.date = transfer.lastInput.Date;
                ViewBag.quantity = transfer.lastInput.LaptopQuantity;
               
                return View(index);
                }
                catch (Exception e)
               {
                    Console.WriteLine("{0} Exception caught.", e);

                if (e.Message =="Sequence contains no elements")
                {

                    //throw new UserNotFoundException();
                    // throw;
                    return RedirectToAction("NotFound");

                }
               
              return View();
            }
        }


        public ActionResult NotFound()
        {
            return View();
        }


        public ActionResult Create()
        {
            try
            {
                ViewData["StoreName"] = StoreName();
                ViewData["LaptopName"] = LaptopName();

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

                if (possibleCount(LaptopID) > 0)
                {

                    transfer.StoreID = storeID;
                    transfer.LaptopID = LaptopID;
                    transfer.LaptopName = laptop(LaptopID);
                    transfer.LaptopQuantity = LaptopQuantity;
                    transfer.Date = DateTime.Now;// add if any field you want insert
                    _db.TransferModels.Add(transfer);
                    _db.SaveChanges();

                    //get Laptop
                    storeFind(storeID).QoP -= LaptopQuantity; // reduce QoP for quantity number
                    _db.SaveChanges();
                    laptopFind(transfer.LaptopID).Quantity -= LaptopQuantity;  // reduce LaptopQuantity from Quantity
                    _db.SaveChanges();

                    transfer.logs(transfer.LaptopName, transfer.LaptopQuantity, storeFind(storeID).Name, storeFind(storeID).Location);

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