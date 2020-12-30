using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Warehouse.Helpers;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface ILaptopRepository
    {
        //Find some laptop
        Task<LaptopModels> laptopFind(int ID);
        //Find stores - list in details for transfers for particular model
        Task<object> stores(int? laptopID);
        //Find some store
        Task<StoreModels> storeFind(int storeID);
        //Create some laptop
        Task<LaptopModels> createLaptop(LaptopModels laptop);
        //Get some laptop by ID
        Task<LaptopModels> getLaptop(int? id);
        //Edit some laptop
        Task<LaptopModels> editLaptop(LaptopModels laptop);
        //Delete laptop
        Task<LaptopModels>deleteLaptop(int? id);
        //List of stores for transfer
        Task<List<SelectListItem>> ddlList();
        //Get sum of full price
        //decimal? sumFullPrice;
        ////Get max number
        //decimal? maxNumber;
        ////Get sum quantity
        //int sumQuantity;
        ////Find last Input in database
        //LaptopModels lastInput;
        ////Find last Input Full Price
        //decimal? lastInputFullPrice;
        ////Find last Input Savings
        //decimal? lastInputSavings;
        ////List of models that have more than 0 Quantity -> for Transfer
        //List<LaptopModels> ChildByIDIfNotZeroQuantity;
        ////Get List by ID order ASC
        //List<LaptopModels> ChildByID;
        //Calculate changes after edit laptop
        Task<LaptopModels> laptopFindAndSaveChanges(int? ID);
            //Create new transfer
        void createTransfer(TransferModels transfer, int id, string name, int quantity, int storeID);
        //Get new companie
        Task<List<Company>> myCompanie();
        //Search and Paging
        Task<object> pageCount(int pageSize, LaptopModels laptop);
        //Get IPagedList for View
        Task<IPagedList<LaptopModels>> pagedLaptop(int? page);
        //Get IPagedList for Search
        Task<IPagedList<LaptopModels>> laptopSearch(int? page, string searchString);
    }
}