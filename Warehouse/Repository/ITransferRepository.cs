using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Helpers;

namespace Warehouse.Repository
{
    interface ITransferRepository
    {
        //Get laptop list
         List<LaptopModels> ListLaptop();
        //Get transfer list with laptop and store name
         object callResult();
        //Store list as new object
         List<TransferResult> storeResult();
        //Get store
         List<SelectListItem> StoreName();
        //Get laptop
         List<SelectListItem> LaptopName();
        //Get laptop counter
         int possibleCount(int LaptopID);
        //Get laptop
         string laptop(int LaptopID);
        //Get store
         StoreModels storeFind(int storeID);
        //Get laptop by Transfer ID
         LaptopModels laptopFind(int TransferLaptopID);
        //Create transfer
        void createTransfer(FormCollection form, TransferModels transfer, TransferRepository transferRepository);
    }
}