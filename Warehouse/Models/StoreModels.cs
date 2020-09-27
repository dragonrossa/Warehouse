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
        [StringLength(50, ErrorMessage = "Name must be between 1 and 50 letters", MinimumLength =1)]
        public string Name { get; set; }
        //Location - not required
        public string Location { get; set; }
        //Zip code - not required
        [Display(Name = "Zip code")]
        public int? ZipCode { get; set; }
        //Address - not required
        public string Address { get; set; }
        //Quantity of Products - not required
        //[Range(1, 500)]
        [Display(Name = "Quantity of products")]
        public int? QoP { get; set; }
        //Stock price - not required
        [Display(Name = "Stock price")]
        [Range(1, 500000)]
        [Column(TypeName = "money")]
        public decimal? StockPrice { get; set; }
        //Contact - telephone - not required
        public string Telephone { get; set; }
        //Email - not required
        public string Email { get; set; }
        //Working time - not required
        [Display(Name = "Working time")]
        public string WorkingTime { get; set; }
        //input - DateTime
        public DateTime? Date { get; set; }
    }
}