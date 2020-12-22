using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        Task<List<ComputerListModels>> computerLists();
        //List of suppliers
        Task<List<SelectListItem>> suppliers();
        //Select list for all computers
        Task<List<SelectListItem>> computers();
        //Select list for all suppliers
        Task<List<SelectListItem>> suppliersforClassicView();
        //Create new Computer
        Task<ComputerListModels> createNewComputer(FormCollection form);
        //List of computers on Index page
        string[] computers(FormCollection form);
        //List of suppliers on Index page
        string[] suppliers(FormCollection form);
        //After change save all records
        Task<string[]> saveAllRecords(FormCollection form);
        //Return classic view for Computers and Suppliers
        Task<ComputerListModels> getClassicViewSuppliers(FormCollection form);
        //Save db
        Task<object> SaveData();
    }
}