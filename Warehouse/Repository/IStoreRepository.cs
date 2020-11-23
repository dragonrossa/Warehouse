using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface IStoreRepository
    {
        //Get all stores
        StoreModels result();
        //Create new store
         StoreModels createStore(StoreModels store);
        //Edit existing store
         StoreModels editStore(StoreModels store);
        //Find some store
         StoreModels findStore(int? id);
        //Delete some store
         StoreModels deleteStore(int? id);

    }
}