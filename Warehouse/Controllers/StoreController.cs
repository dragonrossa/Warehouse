using Microsoft.AspNet.Identity;
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
            var user = User.Identity.GetUserName();

            bool access = (from a in _db.AdminModels where a.Username == user select a.StoreAccess).FirstOrDefault();

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
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }

                return View();

            }
        }

        //GET: MasterData/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
        }

        //POST: MasterData/Create
        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreModels store)
        {
            try
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

                    //Create new log
                    LogModels log = new LogModels
                    {
                        Type = "1",
                        Description = "New store was inserted with name " + result.Name + " on date " + result.Date + " with location on " + result.Location + ".",
                        Date = result.Date
                    };

                    _db.LogModels.Add(log);
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }



                return View(store);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

            
        }

        //GET: MasterData/List
        public ActionResult List()
        {
            try
            {
                List<StoreModels> storeModels = (from k in _db.StoreModels select k).ToList();
                return View(storeModels);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
            
        }

        //GET: MasterData/EditList
        public ActionResult EditList()
        {
            try
            {
                List<StoreModels> storeModels = (from k in _db.StoreModels select k).ToList();
                return View(storeModels);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
            
        }

        ////GET: MasterData/DeleteList
        public ActionResult DeleteList()
        {
            try
            {
                List<StoreModels> storeModels = (from k in _db.StoreModels select k).ToList();
                return View(storeModels);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
        }

        //GET: MasterData/Edit/5
        public ActionResult Edit(int? id)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
            
        }

        //POST: MasterData/Edit/5
        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StoreModels store)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(store).State = EntityState.Modified;
                    _db.SaveChanges();



                    return RedirectToAction("Index");
                }
                return View(store);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
            
        }

        //GET: MasterData/Delete/5

        public ActionResult Delete(int? id)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
        }
        //POST: MasterData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            try
            {
                StoreModels store = _db.StoreModels.Find(id);
                _db.StoreModels.Remove(store);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

            
        }

        //GET: MasterData/Details/1
        public ActionResult Details(int? id)
        {

            try
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
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
        }

       

    }
}
