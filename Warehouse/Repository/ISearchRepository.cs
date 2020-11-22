using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Helpers;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface ISearchRepository
    {
        //If needed, user info
        string userInfo(string userName);
        List<LaptopModels> findSearch(SearchIndex search);
        List<LaptopModels> findSearchOS(SearchIndex search);
        List<StoreModels> findSearchLocation(SearchIndex search);
        LaptopModels searchName(SearchIndex search);
        //Quantity for Laptop
        int? calculateQuantity(SearchIndex search);
        //Quantity for Store
        int? calculateStoreQuantity(SearchIndex search);
        //Quantitiy for Location
        int? calculateLocationQuantity(SearchIndex search);
        //Quantity for ZipCode
        int? calculateZipCodeQuantity(int? test);
        //Quantity for Transfer
        int? calculateTransferQuantity(SearchIndex search);
        //Quantity for Transfer Store Quantity
        int? calculateTransferStoreQuantity(int store);
        LaptopModels searchManufacturer(SearchIndex search);
        LaptopModels searchOS(SearchIndex search);
        StoreModels searchStores(SearchIndex search);
        StoreModels searchZipCode(int? test);
        TransferModels searchStore(int store);
        List<StoreModels> storeList(SearchIndex search);
        List<StoreModels> storeListByZipCode(int? test);
        StoreModels searchLocation(SearchIndex search);
        List<TransferModels> searchTransferByLaptopName(SearchIndex search);
        int storeID(SearchIndex search);
        List<TransferModels> transfer(int store);
        //Create new log
        LogModels log3(SearchIndex search);
        //Create new log
        LogModels log4(SearchIndex search);
    }
}