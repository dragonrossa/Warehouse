using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Helpers;
using Warehouse.DAL;
using System.Threading.Tasks;
using PagedList;
using System.Data.Entity;

namespace Warehouse.Repository
{
    public class TransferRepository: Controller, ITransferRepository
    {
        private WarehouseContext _db = new WarehouseContext();

        //Get List<TransferResult> for search and paging

        List<TransferResult> listOfTransfers = new List<TransferResult>();

        //Get PageParameters object

        PageParameters pages = new PageParameters();

        //Get laptop list
        public async Task<List<LaptopModels>> ListLaptop()
        {

            return (from k in _db.LaptopModels select k).ToList();
        }

        //Get transfer list with laptop and store name
        public async Task<object> callResult()
        {
            return await (from t in _db.TransferModels 
                    join s in _db.StoreModels on t.StoreID equals s.ID 
                    select new { s.Name, t.LaptopName, t.LaptopQuantity }).ToListAsync();
        }

        //Store list as new object
        public async Task<List<TransferResult>> storeResult()
        {
            return await (from t in _db.TransferModels
                    join s in _db.StoreModels on t.StoreID equals s.ID
                    select new TransferResult {  
                        StoreName = s.Name, 
                        LaptopName= t.LaptopName,
                        LaptopQuantity= t.LaptopQuantity }).ToListAsync();

        }


        //Get store
        public async Task<List<SelectListItem>> StoreName()
        {
            return await _db.StoreModels.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToListAsync();
        }

        //Get laptop
        public async Task<List<SelectListItem>> LaptopName()
        {
            return await _db.LaptopModels.Where(u => u.Quantity != 0).Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToListAsync();

        }

        //Get laptop counter
        public async Task<int> possibleCount(int LaptopID)
        {
            return await (from k in _db.LaptopModels where k.ID == LaptopID select k.Quantity).FirstOrDefaultAsync();
        }

        //Get laptop
        public async Task<string> laptop(int LaptopID)
        {
            return await (from k in _db.LaptopModels where k.ID == LaptopID select k.Name).FirstOrDefaultAsync();
        }

        //Get store
        public async Task<StoreModels> storeFind(int storeID)
        {
            return await (from s in _db.StoreModels where s.ID == storeID select s).FirstOrDefaultAsync();
        }

        //Get laptop by Transfer ID
        public async Task<LaptopModels> laptopFind(int TransferLaptopID)
        {
            return await(from k in _db.LaptopModels where k.ID == TransferLaptopID select k).FirstOrDefaultAsync();
        }


        //Create transfer
        public async Task<TransferModels> createTransfer(FormCollection form, TransferModels transfer, TransferRepository transferRepository)
        {
            int storeID = Convert.ToInt32(form["StoreName"].ToString());
            int LaptopID = Convert.ToInt32(form["LaptopName"].ToString());
            int LaptopQuantity = Convert.ToInt32(form["LaptopQuantity"].ToString());

            if (await transferRepository.possibleCount(LaptopID) > 0)
            {

                transfer.StoreID = storeID;
                transfer.LaptopID = LaptopID;
                transfer.LaptopName = await transferRepository.laptop(LaptopID);
                transfer.LaptopQuantity = LaptopQuantity;
                transfer.Date = DateTime.Now;
                _db.TransferModels.Add(transfer);
                await _db.SaveChangesAsync();

                //get Laptop
                var laptop = await transferRepository.storeFind(storeID);
                laptop.QoP -= LaptopQuantity; // reduce QoP for quantity number  
                //  transferRepository.SaveData();
                await _db.SaveChangesAsync();
                var laptopFind = await transferRepository.laptopFind(transfer.LaptopID);
                laptopFind.Quantity -= LaptopQuantity;  // reduce LaptopQuantity from Quantity

               // transferRepository.laptopFind(transfer.LaptopID).Quantity -= LaptopQuantity; 
                await _db.SaveChangesAsync();

                LogModels log = new LogModels
                {
                    Type = "2",
                    Description = "New transfer was inserted with transfer of laptop called " + transfer.LaptopName + " with quantity of " +
                           transfer.LaptopQuantity + " on date " + DateTime.Now + " with location to " + laptop.Name + ", " + laptop.Location + ".",
                    Date = DateTime.Now
                };

                _db.LogModels.Add(log);
                await _db.SaveChangesAsync();

            }
            return transfer;
        }

        //Properties

        public TransferModels lastInput
        {
            get
            {
                return (from k in _db.TransferModels
                        select k)
                               .OrderByDescending(k => k.ID)
                               .First();
            }
        }

        //Search and Paging

        public async Task<object> pageCount(int pageSize, TransferModels transfer)
        {
            int pageCount = transfer.Child.Count();
            int pages = pageCount / pageSize;
            //ViewBag.pageCount = pages;
            int rest = pageCount % pageSize;
            if (rest < 10)
            {
                pages = pages + 1;
                ViewBag.pageCount = pages;
            }
            return ViewBag.pageCount;
        }

        //Get IPagedList for View

        public async Task<IPagedList<TransferResult>> pagedTransfer(int? page)
        {
            listOfTransfers = await storeResult();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            return listOfTransfers.ToPagedList(pageNumber, pageSize);

        }

        //Get IPagedList for Search
        public async Task<IPagedList<TransferResult>> transferSearch(int? page, string searchString)
        {
            listOfTransfers = await storeResult();
            listOfTransfers = listOfTransfers.Where(s => s.LaptopName.Contains(searchString)).ToList();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            return listOfTransfers.ToPagedList(pageNumber, pageSize);
        }

    }
}