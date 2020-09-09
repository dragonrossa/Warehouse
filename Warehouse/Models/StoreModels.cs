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
        [StringLength(50, ErrorMessage = "Name cant have more than 50 letters")]
        public string Name { get; set; }
        //Location - not required
        public string Location { get; set; }
        //Zip code - not required
        [Display(Name = "Zip code")]
        public int? ZipCode { get; set; }
        //Address - not required
        [Column(TypeName = "text")]
        public string Address { get; set; }
        //Quantity of Products - not required
        [Display(Name = "Quantity of products")]
        public int? QoP { get; set; }
        //Stock price - not required
        [Display(Name = "Stock price")]
        [Column(TypeName = "money")]
        public decimal? StockPrice { get; set; }
        //Contact - telephone - not required
        [Column(TypeName = "text")]
        public string Telephone { get; set; }
        //Email - not required
        [Column(TypeName = "text")]
        public string Email { get; set; }
        //Working time - not required
        [Display(Name = "Working time")]
        [Column(TypeName = "text")]
        public string WorkingTime { get; set; }
        //input - DateTime
        public DateTime? Date { get; set; }
    }
}