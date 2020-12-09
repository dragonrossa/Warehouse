using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Helpers;

namespace Warehouse.Models
{
    public class StoreModels:IElement<StoreModels>, ListOrderbyStore<StoreModels>
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //ID - required
        [Key]
        public int ID { get; set; }
        //Name - required
        [Required]
        [RegularExpression(@"^[a-zA-Z  ]{2,50}$", ErrorMessage = "Name must have min 2 and max 50 letters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9 .-]{2,100}$", ErrorMessage = "Location must have min 2 and max 100 letters")]
        //Location - required
        public string Location { get; set; }
        [RegularExpression(@"\d{5}$", ErrorMessage = "Zipcode has 5 digits")]
        //Zip code - not required
        [Display(Name = "Zip code")]
        public int? ZipCode { get; set; }
        //Address - not required
       // [RegularExpression(@"^[a-zA-Z.0-9 ]{5,100}$", ErrorMessage = "Address must have min 5 and max 100 letters")]
        public string Address { get; set; }
        //Quantity of Products - not required
        [Range(1, 500,ErrorMessage ="Quantity cant be bigger from 500")]
        [Display(Name = "Quantity of products")]
        public int? QoP { get; set; }
        //Stock price - not required
        [Display(Name = "Stock price")]
        [Range(1, 500000, ErrorMessage = "Stock price cant be bigger from 500000")]
        [Column(TypeName = "money")]
        public decimal? StockPrice { get; set; }
        //Contact - telephone - not required
        [RegularExpression(@"\d{9,10}$", ErrorMessage = "Telephone number can have 9 or 10 digits")]
        public string Telephone { get; set; }
        //Email - not required
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"+ "@"+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "This is not valid email address!")]
        public string Email { get; set; }
        //Working time - not required
        [Display(Name = "Working time")]
        public string WorkingTime { get; set; }
        //input - DateTime
        public DateTime? Date { get; set; }

        public IEnumerable<StoreModels> store { get; set; }

        [NotMapped]
        public List<StoreModels> Child
        {
            get
            {
                return (from k in _db.StoreModels select k)
                    .OrderBy(x => x.QoP)
                    .ToList();
            }
        }

        [NotMapped]
        public List<StoreModels> Ascending
        {
            get
            {
                return _db.StoreModels.OrderBy(x => x.ID).ToList();
            }
        }

        [NotMapped]
        public List<StoreModels> Descending
        {
            get
            {
                return _db.StoreModels.OrderByDescending(x => x.ID).ToList();
            }
        }

        [NotMapped]
        public List<StoreModels> AscendingByName
        {
            get
            {
                return _db.StoreModels.OrderBy(x => x.Name).ToList();
            }
        }

        [NotMapped]
        public List<StoreModels> DescendingByName
        {
            get
            {
                return _db.StoreModels.OrderByDescending(x => x.Name).ToList();
            }
        }
        [NotMapped]
        public List<StoreModels> AscendingByLocation
        {
            get
            {
                return _db.StoreModels.OrderBy(x => x.Location).ToList();
            }
        }

        [NotMapped]
        public List<StoreModels> DescendingByLocation
        {
            get
            {
                return _db.StoreModels.OrderByDescending(x => x.Location).ToList();
            }
        }
        [NotMapped]
        public List<StoreModels> AscendingByZipcode
        {
            get
            {
                return _db.StoreModels.OrderBy(x => x.ZipCode).ToList();
            }
        }

        [NotMapped]
        public List<StoreModels> DescendingByZipcode
        {
            get
            {
                return _db.StoreModels.OrderByDescending(x => x.ZipCode).ToList();
            }
        }
        [NotMapped]
        public List<StoreModels> AscendingByQuantityOfProducts
        {
            get
            {
                return _db.StoreModels.OrderBy(x => x.QoP).ToList();
            }
        }

        [NotMapped]
        public List<StoreModels> DescendingByQuantityOfProducts
        {
            get
            {
                return _db.StoreModels.OrderByDescending(x => x.QoP).ToList();
            }
        }
    }
}