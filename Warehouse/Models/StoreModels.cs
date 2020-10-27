using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Warehouse.Models
{
    public class StoreModels
    {
        //ID - required
        [Key]
        public int ID { get; set; }
        //Name - required
        [Required]
        [RegularExpression(@"^[a-zA-Z.]{2,30}$", ErrorMessage = "Name must have min 2 and max 30 letters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z.]{2,50}$", ErrorMessage = "Location must have min 2 and max 50 letters")]
        //Location - required
        public string Location { get; set; }
        [RegularExpression(@"\d{5}$", ErrorMessage = "Zipcode has 5 digits")]
        //Zip code - not required
        [Display(Name = "Zip code")]
        public int? ZipCode { get; set; }
        //Address - not required
        [RegularExpression(@"^[a-zA-Z.]{5,100}$", ErrorMessage = "Address must have min 5 and max 100 letters")]
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
    }
}