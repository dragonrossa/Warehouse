using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Helpers;
using System.Threading.Tasks;
using Warehouse.DAL;

namespace Warehouse.Repository
{
    public class LaptopRepository: Controller, ILaptopRepository
    {
        //DB context
        private WarehouseContext _db = new WarehouseContext();

        //Get LaptopModels object

        LaptopModels laptopModels = new LaptopModels();

        //Get Company object

        Company company = new Company();

        //Get List<Company> object

        List<Company> myCompanies = new List<Company>();

        //Find some laptop

        public async Task<LaptopModels> laptopFind(int ID)
        {

            return await (from k in _db.LaptopModels where k.ID == ID select k).FirstOrDefaultAsync();
        }

        //Find stores - list in details for transfers for particular model

        public async Task<object> stores(int? laptopID)
        {


            var stores = await (from t in _db.TransferModels
                          join s in _db.StoreModels on t.StoreID
                          equals s.ID
                          where t.LaptopID == laptopID
                          select s.Name).ToListAsync();


            return ViewBag.storeName = stores.Count == 0 ? ViewBag.storeName = stores : ViewBag.storeName = stores;

        }

        //Find some store

        public async Task<StoreModels> storeFind(int storeID)
        {
            return await (from s in _db.StoreModels where s.ID == storeID select s).FirstOrDefaultAsync();
        }

        //Create some laptop

        public async Task<LaptopModels> createLaptop(LaptopModels laptop)
        {
           _db.LaptopModels.Add(laptop);
           await _db.SaveChangesAsync();

            //Last input in database
            var lastInput = await (from k in _db.LaptopModels
                             select k)
                                .OrderByDescending(k => k.ID)
                                .FirstOrDefaultAsync();

            //Get new full price
            lastInput.FullPrice = await (from k in _db.LaptopModels where k.ID == lastInput.ID select k.Price * k.Quantity).FirstAsync();
           //Get new saving
            lastInput.Savings = await (from k in _db.LaptopModels where k.ID == lastInput.ID select k.OldPrice - k.Price).FirstAsync();
            lastInput.Date = DateTime.Now;
            await _db.SaveChangesAsync();

            //Create new log

                LogModels log = new LogModels
                {
                    Type = "0",
                    Description = "New laptop was inserted with name " + lastInput.Name + " on date " + lastInput.Date + " with quantity of " + lastInput.Quantity + ".",
                    Date = lastInput.Date
                };

                _db.LogModels.Add(log);
                await _db.SaveChangesAsync();

          
            return lastInput;
        }
        

        //Get some laptop by ID
        public async Task<LaptopModels> getLaptop(int? id)
        {
            LaptopModels laptop =  await _db.LaptopModels.FindAsync(id);
            return laptop;
        }

        //Edit some laptop
        public async Task<LaptopModels> editLaptop(LaptopModels laptop)
        {
            _db.Entry(laptop).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return laptop;
        }

        //Delete laptop
        public async Task<LaptopModels> deleteLaptop(int? id)
        {
            LaptopModels laptop = await _db.LaptopModels.FindAsync(id);
            _db.LaptopModels.Remove(laptop);
            await _db.SaveChangesAsync();
            return laptop;
        }

        //List of stores for transfer
        public async Task<List<SelectListItem>> ddlList()
        {
           var list = _db.StoreModels.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            });

            return await list.ToListAsync();
        }

        //Get sum of full price
        public decimal? sumFullPrice
        {
            get
            {
                return laptopModels.Child.Sum(d => d.FullPrice);
   
            }
        }

        //Get max number
        public decimal? maxNumber
        {
            get
            {
                return laptopModels.Child.Sum(d => d.Savings);
            }
        }

        //Get sum quantity
        public int sumQuantity
        {
            get
            {
                return laptopModels.Child.Sum(d => d.Quantity);
            }
        }

        //Find last Input in database
        public LaptopModels lastInput
        {
            get
            {
                return (from k in _db.LaptopModels
                        select k)
                                .OrderByDescending(k => k.ID)
                                .FirstOrDefault();
            }
        }

        //Find last Input Full Price
        public decimal? lastInputFullPrice
        {
            get
            {
                return (from k in _db.LaptopModels where k.ID == lastInput.ID select k.Price * k.Quantity).First();
            }
        }

        //Find last Input Savings
        public decimal? lastInputSavings
        {
            get
            {
                return (from k in _db.LaptopModels where k.ID == lastInput.ID select k.OldPrice - k.Price).First();
            }
        }


        //Calculate PDV, if more of this type do class
        decimal PDV = 25;

        //Find last Input PDV
        public decimal? lastInputPDV
        {
            get
            {
                return (from k in _db.LaptopModels where k.ID == lastInput.ID select k.Price * k.Quantity * (PDV / 100)).First();
            }
            
        }

        //Find last Input FullPriceWithPDV

        public decimal? lastInputFullPriceWithPDV
        {
            get
            {

                return (from k in _db.LaptopModels where k.ID == lastInput.ID select (k.Price * k.Quantity * (PDV / 100)) + (k.Price * k.Quantity)).First();
            }
            
        }

        //List of models that have more t

        public List<LaptopModels> ChildByIDIfNotZeroQuantity
        {
            get
            {
                var list = _db.LaptopModels.ToList().OrderBy(u => u.ID).Select(u => u).ToList();
                var newList = list.Where(i => i.Quantity != 0).ToList();
                return newList;
            }
        }

        //Find list of laptops by ID ASC

        public List<LaptopModels> ChildByID
        {
            get
            {
                return _db.LaptopModels.ToList().OrderBy(u => u.ID).Select(u => u).ToList();
            }
        }

        //Find and save changes to edited laptop
        public async Task<LaptopModels> laptopFindAndSaveChanges(int? ID)
        {
            decimal? PDV = 24;
            var laptopFind = await (from k in _db.LaptopModels where k.ID == ID select k).FirstOrDefaultAsync();
            laptopFind.Savings = await (from k in _db.LaptopModels where k.ID == ID select k.OldPrice - k.Price).FirstOrDefaultAsync();
            await _db.SaveChangesAsync();
            laptopFind.FullPrice = await (from k in _db.LaptopModels where k.ID == ID select k.Price * k.Quantity).FirstOrDefaultAsync();
            laptopFind.PDV = await (from k in _db.LaptopModels where k.ID == ID select k.Price * k.Quantity * (PDV/100)).FirstOrDefaultAsync();
            laptopFind.FullPriceWithPDV = await (from k in _db.LaptopModels where k.ID == ID select (k.Price * k.Quantity * (PDV / 100)) + (k.Price * k.Quantity)).FirstOrDefaultAsync();
            await _db.SaveChangesAsync();
            return laptopFind;
        }

        //Create new transfer
        public async void createTransfer(TransferModels transfer,int id, string name, int quantity, int storeID)
        {
            //Create new Transfer
            transfer.LaptopID = id;
            transfer.LaptopName = name;
            transfer.LaptopQuantity = quantity;
            transfer.StoreID = storeID;
            transfer.Date = DateTime.Now;// add if any field you want insert
            _db.TransferModels.Add(transfer);           // pass the table object
           await _db.SaveChangesAsync();
        }

        //Create new companie
        public async Task<List<Company>> myCompanie()
        {
            
            //Add new company
            company.Name = "Abeceda d.o.o.";
            company.Street = "Ruđera Boškovića 32";
            company.Town = "Zagreb";
            company.ZipCode = "10000";
            company.Country = "Croatia";
            company.OIB = "123123123";

            myCompanies.Add(company);
            
            return myCompanies;
        }
    }
}