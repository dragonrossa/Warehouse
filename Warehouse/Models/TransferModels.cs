using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Warehouse.Helpers;

namespace Warehouse.Models
{
    public class TransferModels:IElement<TransferModels>
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [Key]
        public int ID { get; set; }
        [Display(Name = "Laptop ID")]
        public int LaptopID { get; set; }
        [Display(Name = "Laptop name")]
        public string LaptopName { get; set; }
        [Range(1, 300)]
        [Display(Name = "Laptop quantity")]
        public int LaptopQuantity { get; set; }
        [Display(Name = "Store ID")]
        public int StoreID { get; set; }
        public DateTime? Date { get; set; }

        [NotMapped]

        public List<TransferModels> Child
        {
            get
            {
                return (from k in _db.TransferModels select k).ToList();
            }
        }

        [NotMapped]
        public List<TransferModels> Ascending
        {
            get
            {
                return _db.TransferModels.OrderBy(x => x.ID).ToList();
            }
        }

        [NotMapped]
        public List<TransferModels> Descending
        {
            get
            {
                return _db.TransferModels.OrderByDescending(x => x.ID).ToList();
            }
        }

        [NotMapped]
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


        public LogModels logs(string LaptopName, int LaptopQuantity, string StoreFindName, string StoreFindLocation)
        {
            LogModels log = new LogModels
            {
                Type = "2",
                Description = "New transfer was inserted with transfer of laptop called " + LaptopName + " with quantity of " +
                            LaptopQuantity + " on date " + DateTime.Now + " with location to " + StoreFindName + ", " + StoreFindLocation + ".",
                Date = DateTime.Now
            };

            _db.LogModels.Add(log);
            _db.SaveChanges();
            return log;
        }
    }
}