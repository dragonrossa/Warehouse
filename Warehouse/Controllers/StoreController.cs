using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class StoreController : Controller
    {

        //Get Store Repository
        StoreRepository storeRepository = new StoreRepository();

        //Get Store object

        StoreModels store = new StoreModels();

        // GET: MasterData
        public ActionResult Index()
        {
            
                try
                {

                    ViewBag.store = storeRepository.lastInput.Name;
                    ViewBag.date = storeRepository.lastInput.Date;
                    ViewBag.location = storeRepository.lastInput.Location;

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

                    storeRepository.createStore(store);

                    //Add date on last input
                    storeRepository.result().Date = DateTime.Now;
                    storeRepository.SaveData();

                    //Create new log
                    storeRepository.log(storeRepository.result().Name, storeRepository.result().Date, storeRepository.result().Location);

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
                return View(storeRepository.childOrderByID);
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
                return View(storeRepository.childOrderByID);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
            
        }

        //GET: MasterData/DeleteList
        public ActionResult DeleteList()
        {
            try
            {
              return View(storeRepository.childOrderByID);
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
                if (storeRepository.findStore(id) == null)
                {
                    return HttpNotFound();
                }


                return View(storeRepository.findStore(id));
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

                    storeRepository.editStore(store);

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

                if (storeRepository.findStore(id) == null)
                {
                    return HttpNotFound();
                }
                return View(storeRepository.findStore(id));
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

                storeRepository.deleteStore(id);

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
                storeRepository.findStore(id);

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
