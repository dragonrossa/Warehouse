using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class StoreController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: MasterData
        public ActionResult Index()
        {
            List<StoreModels> storeModels = (from k in _db.StoreModels select k).ToList();
            return View(storeModels);
        }

        //GET: MasterData/Create
        public ActionResult Create()
        {

            return View();
        }

        //POST: MasterData/Create
        [HttpPost]
        public ActionResult Create(StoreModels store)
        {
            if (ModelState.IsValid)
            {
                _db.StoreModels.Add(store);
                _db.SaveChanges();

                //var lastInput = (from k in _db.LaptopModels
                //                 select k)
                //           .OrderByDescending(k => k.ID)
                //           .First();


                //lastInput.FullPrice = (from k in _db.LaptopModels where k.ID == lastInput.ID select k.Price * k.Quantity).First(); //Full price of products
                //lastInput.Savings = (from k in _db.LaptopModels where k.ID == lastInput.ID select k.OldPrice - k.Price).First(); // Savings per unit

                //_db.SaveChanges();

                return RedirectToAction("Index");
            }



            return View(store);
        }

        //GET: MasterData/List
        public ActionResult List()
        {
            List<StoreModels> storeModels = (from k in _db.StoreModels select k).ToList();
            return View(storeModels);
        }

        //GET: MasterData/EditList
        public ActionResult EditList()
        {
            List<StoreModels> storeModels = (from k in _db.StoreModels select k).ToList();
            return View(storeModels);
        }

        ////GET: MasterData/DeleteList
        public ActionResult DeleteList()
        {
            List<StoreModels> storeModels = (from k in _db.StoreModels select k).ToList();
            return View(storeModels);
        }

        //GET: MasterData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModels store = _db.StoreModels.Find(id);

            //var idUser = Convert.ToInt32(id);

            //TempData["id"] = idUser;

            ////Update Full price if price changed in meanwhile

            //var result = (from k in _db.LaptopModels where k.ID == idUser select k.Price * k.Quantity).First(); //select price

            //var savings = (from k in _db.LaptopModels where k.ID == idUser select k.OldPrice - k.Price).First();

            //var laptopFind = (from k in _db.LaptopModels where k.ID == idUser select k).First(); //select laptop

            //laptopFind.FullPrice = Convert.ToDecimal(result); // update FullPrice

            //laptopFind.Savings = Convert.ToDecimal(savings);

            //_db.SaveChanges();

            if (store == null)
            {
                return HttpNotFound();
            }


            return View(store);
        }

        //POST: MasterData/Edit/5
        [HttpPost]
        public ActionResult Edit(StoreModels store)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(store).State = EntityState.Modified;
                _db.SaveChanges();

                //var id = Convert.ToInt32(TempData["id"]);

                //var savings = (from k in _db.LaptopModels where k.ID == id select k.OldPrice - k.Price).First(); //calculate saving

                //var result = (from k in _db.LaptopModels where k.ID == id select k.Price * k.Quantity).First(); //calculate new full price

                //var laptopFind = (from k in _db.LaptopModels where k.ID == id select k).First(); //select laptop

                //laptopFind.Savings = Convert.ToDecimal(savings); //EF Savings

                //laptopFind.FullPrice = Convert.ToDecimal(result);

                //_db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(store);
        }

        //GET: MasterData/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModels store = _db.StoreModels.Find(id);

            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }
        //POST: MasterData/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            StoreModels store = _db.StoreModels.Find(id);
            _db.StoreModels.Remove(store);
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
            StoreModels store = _db.StoreModels.Find(id);

            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

       

    }
}
