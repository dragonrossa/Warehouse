using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Helpers;
using System.Threading.Tasks;
using PagedList;

namespace Warehouse.Repository
{
    interface ITransferRepository
    {
        //Get laptop list
         Task<List<LaptopModels>> ListLaptop();
        //Get transfer list with laptop and store name
         Task<object> callResult();
        //Store list as new object
         Task<List<TransferResult>> storeResult();
        //Get store
         Task<List<SelectListItem>> StoreName();
        //Get laptop
         Task<List<SelectListItem>> LaptopName();
        //Get laptop counter
         Task<int> possibleCount(int LaptopID);
        //Get laptop
         Task<string> laptop(int LaptopID);
        //Get store
         Task<StoreModels> storeFind(int storeID);
        //Get laptop by Transfer ID
         Task<LaptopModels> laptopFind(int TransferLaptopID);
        //Create transfer
         Task<TransferModels> createTransfer(FormCollection form, TransferModels transfer, TransferRepository transferRepository);
        //Search and Paging
        Task<object> pageCount(int pageSize, TransferModels transfer);

        //Get IPagedList for View
        Task<IPagedList<TransferResult>> pagedTransfer(int? page);

        //Get IPagedList for Search
        Task<IPagedList<TransferResult>> transferSearch(int? page, string searchString);
    }
}