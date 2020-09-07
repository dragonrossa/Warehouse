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
            List<StoreModels> storeModels = (from k in _db.StoreModels select k)
                .OrderBy(x => x.QoP)
                .ToList();

            var lastInput = (from k in _db.StoreModels
                             select k)
                       .OrderByDescending(k => k.ID)
                       .First();

            ViewBag.store = lastInput.Name;
            ViewBag.date = lastInput.Date;
            ViewBag.location = lastInput.Location;

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

                var result = (from k in _db.StoreModels
                                              select k)
                          .OrderByDescending(k => k.ID)
                          .First();
                result.Date = DateTime.Now;
                _db.SaveChanges();

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
