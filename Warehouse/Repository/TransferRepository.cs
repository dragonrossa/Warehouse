using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Helpers;

namespace Warehouse.Repository
{
    public class TransferRepository: DatabaseRepository, ITransferRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //Get laptop list
        public List<LaptopModels> ListLaptop()
        {

            return (from k in _db.LaptopModels select k).ToList();
        }

        //Get transfer list with laptop and store name
        public object callResult()
        {
            return (from t in _db.TransferModels 
                    join s in _db.StoreModels on t.StoreID equals s.ID 
                    select new { s.Name, t.LaptopName, t.LaptopQuantity }).ToList();
        }

        //Store list as new object
        public List<TransferResult> storeResult()
        {
            return (from t in _db.TransferModels
                    join s in _db.StoreModels on t.StoreID equals s.ID
                    select new TransferResult {  
                        StoreName = s.Name, 
                        LaptopName= t.LaptopName,
                        LaptopQuantity= t.LaptopQuantity }).ToList();

        }


        //Get store
        public List<SelectListItem> StoreName()
        {
            return _db.StoreModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();
        }

        //Get laptop
        public List<SelectListItem> LaptopName()
        {
            return _db.LaptopModels.Where(u => u.Quantity != 0).ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();

        }

        //Get laptop counter
        public int possibleCount(int LaptopID)
        {
            return (from k in _db.LaptopModels where k.ID == LaptopID select k.Quantity).First();
        }

        //Get laptop
        public string laptop(int LaptopID)
        {
            return (from k in _db.LaptopModels where k.ID == LaptopID select k.Name).First();
        }

        //Get store
        public StoreModels storeFind(int storeID)
        {
            return (from s in _db.StoreModels where s.ID == storeID select s).First();
        }

        //Get laptop by Transfer ID
        public LaptopModels laptopFind(int TransferLaptopID)
        {
            return (from k in _db.LaptopModels where k.ID == TransferLaptopID select k).First();
        }


        //Create transfer
        public void createTransfer(FormCollection form, TransferModels transfer, TransferRepository transferRepository)
        {
            int storeID = Convert.ToInt32(form["StoreName"].ToString());
            int LaptopID = Convert.ToInt32(form["LaptopName"].ToString());
            int LaptopQuantity = Convert.ToInt32(form["LaptopQuantity"].ToString());

            if (transferRepository.possibleCount(LaptopID) > 0)
            {

                transfer.StoreID = storeID;
                transfer.LaptopID = LaptopID;
                transfer.LaptopName = transferRepository.laptop(LaptopID);
                transfer.LaptopQuantity = LaptopQuantity;
                transfer.Date = DateTime.Now;
                transferRepository.addToDatabase(transfer);
                _db.SaveChanges();

                //get Laptop
                transferRepository.storeFind(storeID).QoP -= LaptopQuantity; // reduce QoP for quantity number                                                           //  transferRepository.SaveData();
                _db.SaveChanges();
                transferRepository.laptopFind(transfer.LaptopID).Quantity -= LaptopQuantity;  // reduce LaptopQuantity from Quantity
                _db.SaveChanges();

                transfer.logs(transfer.LaptopName, transfer.LaptopQuantity, transferRepository.storeFind(storeID).Name, transferRepository.storeFind(storeID).Location);
            }
        }

        //Custom Exception for UserNotFound
        public class UserNotFoundException : Exception
        {
            public UserNotFoundException() : base() { }
            public UserNotFoundException(string message) : base(message) { }
            public UserNotFoundException(string message, Exception innerException)
                : base(message, innerException) { }
        }
    }
}