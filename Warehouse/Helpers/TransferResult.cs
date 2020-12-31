using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Warehouse.DAL;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Helpers
{
    public class TransferResult: ListOrderbyTransfer<TransferResult>
    {
        public string StoreName { get; set; } 
        public string LaptopName { get; set; } 
        public int LaptopQuantity { get; set; }
        public IEnumerable<TransferResult> result { get; set; }

        //TransferRepository repository = new TransferRepository();
        //List<TransferResult> transfer = new List<TransferResult>();

        WarehouseContext _db = new WarehouseContext();

        //Store list as new object
        public List<TransferResult> storeResult()
        {
            return  (from t in _db.TransferModels
                          join s in _db.StoreModels on t.StoreID equals s.ID
                          select new TransferResult
                          {
                              StoreName = s.Name,
                              LaptopName = t.LaptopName,
                              LaptopQuantity = t.LaptopQuantity
                          }).ToList();

        }


        [NotMapped]
        public List<TransferResult> AscendingByName
        {
            get
            {
                return storeResult().OrderBy(x => x.LaptopName).ToList();
            }
        }
        [NotMapped]
        public List<TransferResult> DescendingByName
        {
            get
            {
                return storeResult().OrderByDescending(x => x.LaptopName).ToList();
            }
        }

        [NotMapped]
        public List<TransferResult> AscendingByQuantity
        {
            get
            {
                return storeResult().OrderBy(x => x.LaptopQuantity).ToList();
            }
        }
        [NotMapped]
        public List<TransferResult> DescendingByQuantity
        {
            get
            {
                return storeResult().OrderByDescending(x => x.LaptopQuantity).ToList();
            }
        }
        [NotMapped]
        public List<TransferResult> AscendingByPlace
        {
            get
            {
                return storeResult().OrderBy(x => x.StoreName).ToList();
            }
        }
        [NotMapped]
        public List<TransferResult> DescendingByPlace
        {
            get
            {
                return storeResult().OrderByDescending(x => x.StoreName).ToList();
            }
        }
    }
}