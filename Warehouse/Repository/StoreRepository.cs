using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class StoreRepository:DatabaseRepository,IStoreRepository
    {
        //DB Context
        private WarehouseContext _db = new WarehouseContext();

        //Get all stores
        public StoreModels result()
        {
            return (from k in _db.StoreModels select k)
                             .OrderByDescending(k => k.ID)
                             .First();
        }

        //Create new store
        public StoreModels createStore(StoreModels store)
        {
            _db.StoreModels.Add(store);
            _db.SaveChanges();
            return store;
        }

        //Edit existing store
        public StoreModels editStore(StoreModels store)
        {
            _db.Entry(store).State = EntityState.Modified;
            _db.SaveChanges();
            return store;
        }

        //Find some store

        public StoreModels findStore(int? id)
        {
            StoreModels store = _db.StoreModels.Find(id);
            return store;
        }

        //Delete some store
        public StoreModels deleteStore(int? id)
        {
            StoreModels store = _db.StoreModels.Find(id);
            _db.StoreModels.Remove(store);
            _db.SaveChanges();
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
                               .First();
            }
        }

        public List<StoreModels> childOrderByID
        {
            get
            {
                return (from k in _db.StoreModels orderby k.ID select k).ToList();
            }
        }

        public LogModels log(string ResultName, DateTime? ResultDate, string ResultLocation)
        {
            LogModels log = new LogModels
            {
                Type = "1",
                Description = "New store was inserted with name " + ResultName + " on date " + ResultDate + " with location on " + ResultLocation + ".",
                Date = ResultDate
            };

            _db.LogModels.Add(log);
            _db.SaveChanges();
            return log;
        }
    }
}