using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class LaptopController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: MasterData
        public ActionResult Index()
        {
            List<LaptopModels> ListLaptop = (from k in _db.LaptopModels select k).ToList();
            return View(ListLaptop);
        }

        //GET: MasterData/Create
        public ActionResult Create()
        {

            return View();
        }

        //POST: MasterData/Create
        [HttpPost]
        public ActionResult Create(LaptopModels laptop)
        {
            if (ModelState.IsValid)
            {
                _db.LaptopModels.Add(laptop);
                _db.SaveChanges();

                var lastInput = (from k in _db.LaptopModels
                                 select k)
                           .OrderByDescending(k => k.ID)
                           .First();

              
                lastInput.FullPrice = (from k in _db.LaptopModels where k.ID == lastInput.ID select k.Price * k.Quantity).First(); //Full price of products
                lastInput.Savings = (from k in _db.LaptopModels where k.ID == lastInput.ID select k.OldPrice - k.Price).First(); // Savings per unit

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

          

            return View(laptop);
        }

        //GET: MasterData/List
        public ActionResult List()
        {
            List<LaptopModels> ListLaptop = (from k in _db.LaptopModels select k).ToList();
            return View(ListLaptop);
        }

        //GET: MasterData/EditList
        public ActionResult EditList()
        {
            List<LaptopModels> Laptop = (from k in _db.LaptopModels select k).ToList();
            return View(Laptop);
        }

        ////GET: MasterData/DeleteList
        public ActionResult DeleteList()
        {
            List<LaptopModels> Laptop = (from k in _db.LaptopModels select k).ToList();
            return View(Laptop);
        }

        //GET: MasterData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaptopModels laptop = _db.LaptopModels.Find(id);

            var idUser = Convert.ToInt32(id);

            TempData["id"] = idUser;

            //Update Full price if price changed in meanwhile

            var result = (from k in _db.LaptopModels where k.ID == idUser select k.Price * k.Quantity).First(); //select price

            var savings = (from k in _db.LaptopModels where k.ID == idUser select k.OldPrice - k.Price).First();

            var laptopFind = (from k in _db.LaptopModels where k.ID == idUser select k).First(); //select laptop

            laptopFind.FullPrice = Convert.ToDecimal(result); // update FullPrice

            laptopFind.Savings = Convert.ToDecimal(savings);

            _db.SaveChanges();

            if (laptop == null)
            {
                return HttpNotFound();
            }

            
            return View(laptop);
        }

        //POST: MasterData/Edit/5
        [HttpPost]
        public ActionResult Edit(LaptopModels laptop)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(laptop).State = EntityState.Modified;
                _db.SaveChanges();

                var id = Convert.ToInt32(TempData["id"]);

                var savings = (from k in _db.LaptopModels where k.ID == id select k.OldPrice - k.Price).First(); //calculate saving

                var result = (from k in _db.LaptopModels where k.ID == id select k.Price * k.Quantity).First(); //calculate new full price

                var laptopFind = (from k in _db.LaptopModels where k.ID == id select k).First(); //select laptop

                laptopFind.Savings = Convert.ToDecimal(savings); //EF Savings

                laptopFind.FullPrice = Convert.ToDecimal(result);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(laptop);
        }

        //GET: MasterData/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaptopModels laptop = _db.LaptopModels.Find(id);

            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }
        //POST: MasterData/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            LaptopModels laptop = _db.LaptopModels.Find(id);
            _db.LaptopModels.Remove(laptop);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: MasterData/Details/1
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaptopModels laptop = _db.LaptopModels.Find(id);

            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        public ActionResult Result()
        {
            

            var laptop = (from k in _db.LaptopModels select k).ToList();

            var result = (from k in _db.LaptopModels select k.Price*k.Quantity).ToList();


            foreach(var lap in laptop)
            {
               
                foreach(var res in result)
                {
                    
                    lap.FullPrice = Convert.ToDecimal(res);
                 
                    _db.SaveChanges();

                }

            }

          
            ViewBag.selectResult = "abcd";



            return View(result);
        }


        //GET: MasterData/Send
        public ActionResult Send()
        {
            List<LaptopModels> ListLaptop = (from k in _db.LaptopModels select k).ToList();
            return View(ListLaptop);
        }

        //GET: MasterData/Send
        public ActionResult SendArticle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaptopModels laptop = _db.LaptopModels.Find(id);

            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        //GET:MasterData/Check
        public ActionResult Check(int? id, string name, int quantity)
        {
            @ViewBag.id = id;
            ViewBag.name = name;
            @ViewBag.number = quantity;
            return View();
        }

    }
}
