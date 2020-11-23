using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class StoreRepository:DatabaseRepository,IStoreRepository
    {
        //DB Context
        private ApplicationDbContext _db = new ApplicationDbContext();

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

        //Exception

        public class UserNotFoundException : Exception
        {
            public UserNotFoundException() : base() { }
            public UserNotFoundException(string message) : base(message) { }
            public UserNotFoundException(string message, Exception innerException)
                : base(message, innerException) { }
        }
    }
}