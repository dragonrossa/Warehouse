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

        StoreModels store = new StoreModels();

        public StoreModels result()
        {
            return (from k in _db.StoreModels select k)
                             .OrderByDescending(k => k.ID)
                             .First();
        }

        public StoreModels createStore(StoreModels store)
        {
            _db.StoreModels.Add(store);
            _db.SaveChanges();
            return store;
        }

        public StoreModels editStore(StoreModels store)
        {
            _db.Entry(store).State = EntityState.Modified;
            _db.SaveChanges();
            return store;
        }

        public StoreModels findStore(int? id)
        {
            StoreModels store = _db.StoreModels.Find(id);
            return store;
        }

        public StoreModels deleteStore(int? id)
        {
            StoreModels store = _db.StoreModels.Find(id);
            _db.StoreModels.Remove(store);
            _db.SaveChanges();
            return store;
        }
        

        public class UserNotFoundException : Exception
        {
            public UserNotFoundException() : base() { }
            public UserNotFoundException(string message) : base(message) { }
            public UserNotFoundException(string message, Exception innerException)
                : base(message, innerException) { }
        }

        // GET: MasterData
        public ActionResult Index()
        {
            
                try
                {

                    ViewBag.store = store.lastInput.Name;
                    ViewBag.date = store.lastInput.Date;
                    ViewBag.location = store.lastInput.Location;

                    return View(store.Child);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);

                //redirect if there are no Laptopmodels in list
                if (e.Message == "Sequence contains no elements")
                {

                    //throw new UserNotFoundException();
                    // throw;
                    return RedirectToAction("NotFound");

                }


            }

                return View();

            
        }



        //Exception - UserNotFound

        public ActionResult NotFound()
        {
            return View();
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
                    //Add new store

                    createStore(store);

                    //Add date on last input
                    result().Date = DateTime.Now;
                    _db.SaveChanges();

                    //Create new log
                    store.log(result().Name, result().Date, result().Location);

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
                return View(store.childOrderByID);
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
                return View(store.childOrderByID);
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
              return View(store.childOrderByID);
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

                //Find store
                if (findStore(id) == null)
                {
                    return HttpNotFound();
                }


                return View(findStore(id));
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
                    //Modify store, return store

                    editStore(store);

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
                //StoreModels store = _db.StoreModels.Find(id);

                if (findStore(id) == null)
                {
                    return HttpNotFound();
                }
                return View(findStore(id));
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
               
                //Delete Store

                deleteStore(id);

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
                findStore(id);
                //StoreModels store = _db.StoreModels.Find(id);

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
