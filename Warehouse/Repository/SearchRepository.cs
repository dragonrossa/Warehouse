using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Helpers;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class SearchRepository:DatabaseRepository, ISearchRepository
    {
        //Call database
        private ApplicationDbContext _db = new ApplicationDbContext();

        //Create class object
        SearchIndex search = new SearchIndex();

        //Initialize new Search List
        List<SearchIndex> index = new List<SearchIndex>();


        //If needed, user info
        public string userInfo(string userName)
        {
            var user = userName;
            return user;
        }


        public List<LaptopModels> findSearch(SearchIndex search)
        {

            int QuantityOfAllProducts = (from k in _db.LaptopModels
                                         where k.Manufacturer == search.Name
                                         select k).Count();
            search.QuantityOfAllProducts = (from k in _db.LaptopModels
                                            where k.OS == search.Name
                                            select k).Count();
            List<LaptopModels> laptops = (from k in _db.LaptopModels
                                          where k.Manufacturer == search.Name
                                          select k).ToList();
            return laptops;

        }

        public List<LaptopModels> findSearchOS(SearchIndex search)
        {


            int QuantityOfAllProducts = (from k in _db.LaptopModels
                                         where k.OS == search.Name
                                         select k).Count();
            search.QuantityOfAllProducts = (from k in _db.LaptopModels
                                            where k.OS == search.Name
                                            select k).Count();
            List<LaptopModels> laptops = (from k in _db.LaptopModels
                                          where k.OS == search.Name
                                          select k).ToList();
            return laptops;

        }

        public List<StoreModels> findSearchLocation(SearchIndex search)
        {

            List<StoreModels> stores = (from k in _db.StoreModels
                                        where k.Location == search.Name
                                        select k).ToList();
            return stores;

        }



        public LaptopModels searchName(SearchIndex search)
        {
            return (from k in _db.LaptopModels
                    where k.Name == search.Name
                    select k).FirstOrDefault();
        }


        //Quantity for Laptop
        public int? calculateQuantity(SearchIndex search)
        {
            return (from k in _db.LaptopModels
                    where k.Name == search.Name
                    select (int?)k.Quantity).Sum();
        }

        //Quantity for Store
        public int? calculateStoreQuantity(SearchIndex search)
        {
            return (from k in _db.StoreModels
                    where k.Name == search.Name
                    select (int?)k.QoP).Sum();
        }

        //Quantitiy for Location
        public int? calculateLocationQuantity(SearchIndex search)
        {
            return (from k in _db.StoreModels
                    where k.Location == search.Name
                    select (int?)k.QoP).Sum();
        }

        //Quantity for ZipCode
        public int? calculateZipCodeQuantity(int? test)
        {
            return (from k in _db.StoreModels
                    where k.ZipCode == test
                    select (int?)k.QoP).Sum();
        }

        //Quantity for Transfer
        public int? calculateTransferQuantity(SearchIndex search)
        {
            return (from k in _db.TransferModels
                    where k.LaptopName == search.Name
                    select (int?)k.LaptopQuantity).Sum();
        }

        //Quantity for Transfer Store Quantity
        public int? calculateTransferStoreQuantity(int store)
        {
            return (from t in _db.TransferModels
                    where t.StoreID == store
                    select (int?)t.LaptopQuantity).Sum();
        }

        public LaptopModels searchManufacturer(SearchIndex search)
        {
            return (from k in _db.LaptopModels
                    where k.Manufacturer == search.Name
                    select k).FirstOrDefault();
        }

        public LaptopModels searchOS(SearchIndex search)
        {
            return (from k in _db.LaptopModels
                    where k.OS == search.Name
                    select k).FirstOrDefault();
        }

        public StoreModels searchStores(SearchIndex search)
        {
            return (from k in _db.StoreModels
                    where k.Name == search.Name
                    select k).FirstOrDefault();
        }

        public StoreModels searchZipCode(int? test)
        {
            return (from k in _db.StoreModels
                    where k.ZipCode == test
                    select k).FirstOrDefault();
        }

        public TransferModels searchStore(int store)
        {
            return (from t in _db.TransferModels
                    where t.StoreID == store
                    select t).FirstOrDefault();
        }

        public List<StoreModels> storeList(SearchIndex search)
        {
            return (from k in _db.StoreModels
                    where k.Name == search.Name
                    select k).ToList();
        }

        public List<StoreModels> storeListByZipCode(int? test)
        {
            return (from k in _db.StoreModels
                    where k.ZipCode == test
                    select k).ToList();
        }


        public StoreModels searchLocation(SearchIndex search)
        {
            return (from k in _db.StoreModels
                    where k.Location == search.Name
                    select k).FirstOrDefault();
        }

        public List<TransferModels> searchTransferByLaptopName(SearchIndex search)
        {
            return (from k in _db.TransferModels
                    where k.LaptopName == search.Name
                    select k).ToList();
        }


        public int storeID(SearchIndex search)
        {
            return (from s in _db.StoreModels
                    where s.Name == search.Name
                    select s.ID).SingleOrDefault();

        }

        public List<TransferModels> transfer(int store)
        {
            return (from t in _db.TransferModels
                    where t.StoreID == store
                    select t).ToList();
        }

        //Create new log
        public LogModels log3(SearchIndex search)
        {
            LogModels log = new LogModels
            {
                Type = "3",
                Description = "There was new search in Laptop section for " + search.Name + ".",
                Date = DateTime.Now
            };

            _db.LogModels.Add(log);
            _db.SaveChanges();
            return log;
        }


        //Create new log
        public LogModels log4(SearchIndex search)
        {
            LogModels log = new LogModels
            {
                Type = "4",
                Description = "There was new search in Transfer section for " + search.Name + ".",
                Date = DateTime.Now
            };

            _db.LogModels.Add(log);
            _db.SaveChanges();
            return log;
        }


    }
}