using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class LaptopRepository: Controller, ILaptopRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public LaptopModels laptopFind(int ID)
        {

            return (from k in _db.LaptopModels where k.ID == ID select k).FirstOrDefault();
        }


        public decimal? laptopFindSavings(int ID)
        {

            return (from k in _db.LaptopModels where k.ID == ID select k.OldPrice - k.Price).FirstOrDefault();

        }

        public decimal? laptopFindFullPrice(int ID)
        {

            return (from k in _db.LaptopModels where k.ID == ID select k.Price * k.Quantity).FirstOrDefault();

        }

        public object stores(int? laptopID)
        {


            var stores = (from t in _db.TransferModels
                          join s in _db.StoreModels on t.StoreID
                          equals s.ID
                          where t.LaptopID == laptopID
                          select s.Name).ToList();


            return ViewBag.storeName = stores.Count == 0 ? ViewBag.storeName = stores : ViewBag.storeName = stores;

        }

        public StoreModels storeFind(int storeID)
        {
            return (from s in _db.StoreModels where s.ID == storeID select s).First();
        }

        public void createLaptop(LaptopModels laptop, LaptopModels laptop1)
        {
            _db.LaptopModels.Add(laptop);
            _db.SaveChanges();

            //Last input in database
            var lastInput = laptop1.lastInput;

            lastInput.FullPrice = laptop1.lastInputFullPrice;
            lastInput.Savings = laptop1.lastInputSavings;
            lastInput.Date = laptop1.lastInputDate;
            _db.SaveChanges();

            //Create new log

            laptop1.CreateLog(lastInput.Name, lastInput.Date, lastInput.Quantity);
        }

        public LaptopModels getLaptop(int? id)
        {
            LaptopModels laptop = _db.LaptopModels.Find(id);
            return laptop;
        }

        public void editLaptop(LaptopModels laptop)
        {
            _db.Entry(laptop).State = EntityState.Modified;
            _db.SaveChanges();

            //var ID = Convert.ToInt32(TempData["id"]);
            //return ID;

        }

        public void deleteLaptop(int? id)
        {
            LaptopModels laptop = _db.LaptopModels.Find(id);
            _db.LaptopModels.Remove(laptop);
            _db.SaveChanges();
        }

        public List<SelectListItem> ddlList()
        {
           return _db.StoreModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();
        }

    }
}