using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Helpers;

namespace Warehouse.Repository
{
    public class LaptopRepository: Controller, ILaptopRepository
    {
        //DB context
        private ApplicationDbContext _db = new ApplicationDbContext();

        //Get LaptopModels object

        LaptopModels laptopModels = new LaptopModels();

        //Get Company object

        Company company = new Company();

        //Get List<Company> object

        List<Company> myCompanies = new List<Company>();

        //Find some laptop

        public LaptopModels laptopFind(int ID)
        {

            return (from k in _db.LaptopModels where k.ID == ID select k).FirstOrDefault();
        }

        //Find stores - list in details for transfers for particular model

        public object stores(int? laptopID)
        {


            var stores = (from t in _db.TransferModels
                          join s in _db.StoreModels on t.StoreID
                          equals s.ID
                          where t.LaptopID == laptopID
                          select s.Name).ToList();


            return ViewBag.storeName = stores.Count == 0 ? ViewBag.storeName = stores : ViewBag.storeName = stores;

        }

        //Find some store

        public StoreModels storeFind(int storeID)
        {
            return (from s in _db.StoreModels where s.ID == storeID select s).First();
        }

        //Create some laptop

        public void createLaptop(LaptopModels laptop)
        {
            _db.LaptopModels.Add(laptop);
            _db.SaveChanges();

            //Last input in database
            var lastInput = (from k in _db.LaptopModels
                             select k)
                                .OrderByDescending(k => k.ID)
                                .FirstOrDefault();

            //Get new full price
            lastInput.FullPrice = (from k in _db.LaptopModels where k.ID == lastInput.ID select k.Price * k.Quantity).First();
           //Get new saving
            lastInput.Savings = (from k in _db.LaptopModels where k.ID == lastInput.ID select k.OldPrice - k.Price).First();
            lastInput.Date = DateTime.Now;
            _db.SaveChanges();

            //Create new log

                LogModels log = new LogModels
                {
                    Type = "0",
                    Description = "New laptop was inserted with name " + lastInput.Name + " on date " + lastInput.Date + " with quantity of " + lastInput.Quantity + ".",
                    Date = lastInput.Date
                };

                _db.LogModels.Add(log);
                _db.SaveChanges();
        }
        

        //Get some laptop by ID
        public LaptopModels getLaptop(int? id)
        {
            LaptopModels laptop = _db.LaptopModels.Find(id);
            return laptop;
        }

        //Edit some laptop
        public void editLaptop(LaptopModels laptop)
        {
            _db.Entry(laptop).State = EntityState.Modified;
            _db.SaveChanges();
        }

        //Delete laptop
        public void deleteLaptop(int? id)
        {
            LaptopModels laptop = _db.LaptopModels.Find(id);
            _db.LaptopModels.Remove(laptop);
            _db.SaveChanges();
        }

        //List of stores for transfer
        public List<SelectListItem> ddlList()
        {
           return _db.StoreModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();
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
        public void laptopFindAndSaveChanges(int? ID)
        {
            var laptopFind = (from k in _db.LaptopModels where k.ID == ID select k).FirstOrDefault();

            laptopFind.Savings = (from k in _db.LaptopModels where k.ID == ID select k.OldPrice - k.Price).FirstOrDefault();
            _db.SaveChanges();
            laptopFind.FullPrice = (from k in _db.LaptopModels where k.ID == ID select k.Price * k.Quantity).FirstOrDefault();
            _db.SaveChanges();
        }

        //Create new transfer
        public void createTransfer(TransferModels transfer,int id, string name, int quantity, int storeID)
        {
            //Create new Transfer
            transfer.LaptopID = id;
            transfer.LaptopName = name;
            transfer.LaptopQuantity = quantity;
            transfer.StoreID = storeID;
            transfer.Date = DateTime.Now;// add if any field you want insert
            _db.TransferModels.Add(transfer);           // pass the table object
            _db.SaveChanges();
        }

        //Create new companie
        public List<Company> myCompanie()
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