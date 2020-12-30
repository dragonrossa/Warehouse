using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface IStoreRepository
    {
        //Get all stores
         Task<StoreModels> result();
        //Create new store
         Task<StoreModels> createStore(StoreModels store);
        //Edit existing store
         Task<StoreModels> editStore(StoreModels store);
        //Find some store
         Task<StoreModels> findStore(int? id);
        //Delete some store
         Task<StoreModels> deleteStore(int? id);
        //Search and Paging
        Task<object> pageCount(int pageSize, StoreModels store);
        //Get IPagedList for View
        Task<IPagedList<StoreModels>> pagedStore(int? page);
        //Get IPagedList for Search
        Task<IPagedList<StoreModels>> storeSearch(int? page, string searchString);

    }
}