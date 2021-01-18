using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Warehouse.DAL;
using Warehouse.Models;
using Warehouse.Repository;
using PagedList;

namespace Warehouse.Controllers
{
    public class StoreController : Controller
    {

        //Get DB Context

        private WarehouseContext _db = new WarehouseContext();

        //Get Store Repository
        StoreRepository storeRepository = new StoreRepository();

        //Get Store object

        StoreModels store = new StoreModels();

        //Override OnException

        //protected override void OnException(ExceptionContext filterContext)
        //{

        //    Exception ex = filterContext.Exception;
        //    filterContext.ExceptionHandled = true;

        //    var model = new HandleErrorInfo(filterContext.Exception, "Store", "Index");

        //    filterContext.Result = new ViewResult()
        //    {
        //        ViewName = "ErrorMessage",
        //        ViewData = new ViewDataDictionary(model)
        //    };
        //}


        // GET: MasterData
        public async Task<ActionResult> Index(string searchString, string sortOrder, int? page)
        {
            
                try
                {

                //Paging and search

                ViewBag.CurrentSort = sortOrder;
                ViewBag.pageNumber = page ?? 1;


                int pageSize = 10;
                int pageNumber = page ?? 1;



                //Get ViewBag.pageCount
                ViewBag.pageCount = await storeRepository.pageCount(pageSize, store);

                //Search box

                if (!String.IsNullOrEmpty(searchString))
                {

                    return View(await storeRepository.storeSearch(page, searchString));
                }

                //Session for controllers

                Session["pageNumber"] = pageNumber;
                Session["pageSize"] = pageSize;

                ViewBag.store = storeRepository.lastInput.Name;
                ViewBag.date = storeRepository.lastInput.Date;
                ViewBag.location = storeRepository.lastInput.Location;



                return View(await storeRepository.pagedStore(page));

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

        public async Task<ActionResult> NotFound()
        {


            return View();
        }




        //GET: MasterData/Create
        public async Task<ActionResult> Create()
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
        public async Task<ActionResult> Create(StoreModels store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Add new store

                    await storeRepository.createStore(store);

                    //Add date on last input

                    var storeLast = await storeRepository.result();
                    storeLast.Date = DateTime.Now;
                    storeRepository.SaveData();

                    //Create new log
                    await storeRepository.log(storeLast.Name, storeLast.Date, storeLast.Location);

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
        public async Task<ActionResult> List(string searchString, string sortOrder, int? page)
        {
            try
            {
                //Paging and search

                ViewBag.CurrentSort = sortOrder;
                ViewBag.pageNumber = page ?? 1;


                int pageSize = 10;
                int pageNumber = page ?? 1;



                //Get ViewBag.pageCount
                ViewBag.pageCount = await storeRepository.pageCount(pageSize, store);

                //Search box

                if (!String.IsNullOrEmpty(searchString))
                {

                    return View(await storeRepository.storeSearch(page, searchString));
                }

                //Session for controllers

                Session["pageNumber"] = pageNumber;
                Session["pageSize"] = pageSize;

                ViewBag.store = storeRepository.lastInput.Name;
                ViewBag.date = storeRepository.lastInput.Date;
                ViewBag.location = storeRepository.lastInput.Location;



                return View(await storeRepository.pagedStore(page));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
            
        }

        //GET: MasterData/EditList
        public async Task<ActionResult> EditList(string searchString, string sortOrder, int? page)
        {
            try
            {
                //Paging and search

                ViewBag.CurrentSort = sortOrder;
                ViewBag.pageNumber = page ?? 1;


                int pageSize = 10;
                int pageNumber = page ?? 1;



                //Get ViewBag.pageCount
                ViewBag.pageCount = await storeRepository.pageCount(pageSize, store);

                //Search box

                if (!String.IsNullOrEmpty(searchString))
                {

                    return View(await storeRepository.storeSearch(page, searchString));
                }

                //Session for controllers

                Session["pageNumber"] = pageNumber;
                Session["pageSize"] = pageSize;

                ViewBag.store = storeRepository.lastInput.Name;
                ViewBag.date = storeRepository.lastInput.Date;
                ViewBag.location = storeRepository.lastInput.Location;



                return View(await storeRepository.pagedStore(page));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
            
        }

        //GET: MasterData/DeleteList
        public async Task<ActionResult> DeleteList(string searchString, string sortOrder, int? page)
        {
            try
            {
                //Paging and search

                ViewBag.CurrentSort = sortOrder;
                ViewBag.pageNumber = page ?? 1;


                int pageSize = 10;
                int pageNumber = page ?? 1;



                //Get ViewBag.pageCount
                ViewBag.pageCount = await storeRepository.pageCount(pageSize, store);

                //Search box

                if (!String.IsNullOrEmpty(searchString))
                {

                    return View(await storeRepository.storeSearch(page, searchString));
                }

                //Session for controllers

                Session["pageNumber"] = pageNumber;
                Session["pageSize"] = pageSize;

                ViewBag.store = storeRepository.lastInput.Name;
                ViewBag.date = storeRepository.lastInput.Date;
                ViewBag.location = storeRepository.lastInput.Location;



                return View(await storeRepository.pagedStore(page));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();
        }

        //GET: MasterData/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
        public async Task<ActionResult> Edit(StoreModels store)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    //Modify store, return store

                    await storeRepository.editStore(store);

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

        public async Task<ActionResult> Delete(int? id)
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
        public async Task<ActionResult> Delete(int id)
        {

            try
            {

                //Delete Store

                await storeRepository.deleteStore(id);

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return View();

            
        }

        //GET: MasterData/Details/1
        public async Task<ActionResult> Details(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                await storeRepository.findStore(id);

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
