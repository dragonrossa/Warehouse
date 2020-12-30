using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class StoreRepository:Controller, IStoreRepository, IDatabaseRepository
    {
        //DB Context
        private WarehouseContext _db = new WarehouseContext();

        //Get List<StoreModels> for search and paging

        List<StoreModels> listOfStores = new List<StoreModels>();

        //Inherited from IDatabaseRepository

        //Get DB
        public WarehouseContext Data(WarehouseContext _db)
        {

            this._db = _db;
            return _db;
        }

        //Inherited from IDatabaseRepository

        //Save DB
        public object SaveData()
        {

            return _db.SaveChanges();
        }

        //Get all stores
        public async Task<StoreModels> result()
        {
            return await (from k in _db.StoreModels select k)
                             .OrderByDescending(k => k.ID)
                             .FirstOrDefaultAsync();
        }

        //Create new store
        public async Task<StoreModels> createStore(StoreModels store)
        {
            _db.StoreModels.Add(store);
            await _db.SaveChangesAsync();
            return store;
        }

        //Edit existing store
        public async Task<StoreModels> editStore(StoreModels store)
        {
            _db.Entry(store).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return store;
        }

        //Find some store

        public async Task<StoreModels> findStore(int? id)
        {
            StoreModels store = await _db.StoreModels.FindAsync(id);
            return store;
        }

        //Delete some store
        public async Task<StoreModels> deleteStore(int? id)
        {
            StoreModels store = await _db.StoreModels.FindAsync(id);
            _db.StoreModels.Remove(store);
            await _db.SaveChangesAsync();
            return store;
        }

        
        //Property

        public StoreModels lastInput
        {
            get
            {
                return (from k in _db.StoreModels
                        select k)
                               .OrderByDescending(k => k.ID)
                               .FirstOrDefault();
            }
        }

        public List<StoreModels> childOrderByID
        {
            get
            {
                return (from k in _db.StoreModels orderby k.ID select k).ToList();
            }
        }

        public async Task<LogModels> log(string ResultName, DateTime? ResultDate, string ResultLocation)
        {
            LogModels log = new LogModels
            {
                Type = "1",
                Description = "New store was inserted with name " + ResultName + " on date " + ResultDate + " with location on " + ResultLocation + ".",
                Date = ResultDate
            };

            _db.LogModels.Add(log);
            await _db.SaveChangesAsync();
            return log;
        }

        //Search and Paging

        public async Task<object> pageCount(int pageSize, StoreModels store)
        {
            int pageCount = store.Child.Count();
            int pages = pageCount / pageSize;
            //ViewBag.pageCount = pages;
            int rest = pageCount % pageSize;
            if (rest < 10)
            {
                pages = pages + 1;
                ViewBag.pageCount = pages;
            }
            return ViewBag.pageCount;
        }

        //Get IPagedList for View

        public async Task<IPagedList<StoreModels>> pagedStore(int? page)
        {
            listOfStores = await (from s in _db.StoreModels select s).ToListAsync();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            return listOfStores.ToPagedList(pageNumber, pageSize);

        }

        //Get IPagedList for Search
        public async Task<IPagedList<StoreModels>> storeSearch(int? page, string searchString)
        {
            listOfStores = await _db.StoreModels.Where(s => s.Name.Contains(searchString)).ToListAsync();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            return listOfStores.ToPagedList(pageNumber, pageSize);
        }
    }
}