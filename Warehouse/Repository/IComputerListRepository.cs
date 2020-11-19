using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface IComputerListRepository
    {
        //Get DB
        ApplicationDbContext Data(ApplicationDbContext _db);
        //Return List of computers
        List<ComputerListModels> computerLists();
        //List of suppliers
        List<SelectListItem> suppliers();
        //Select list for all computers
        List<SelectListItem> computers();
        //Select list for all suppliers
        List<SelectListItem> suppliersforClassicView();
        //Create new Computer
        ComputerListModels createNewComputer(FormCollection form);
        //List of computers on Index page
        string[] computers(FormCollection form);
        //List of suppliers on Index page
        string[] suppliers(FormCollection form);
        //After change save all records
        string[] saveAllRecords(FormCollection form);
        //Return classic view for Computers and Suppliers
        ComputerListModels getClassicViewSuppliers(FormCollection form);
        //Save db
        object SaveData();
    }
}