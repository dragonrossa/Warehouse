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

            if (laptop == null)
            {
                return HttpNotFound();
            }

            //List<MasterData> ListMaster = (from k in _db.LaptopModels select k).ToList();
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

    }
}
