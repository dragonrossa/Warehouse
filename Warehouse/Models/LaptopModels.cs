using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class LaptopModels
    {
        //ID
        [Key]
        public int ID { get; set; }
        //Name
        [Required]
        [StringLength(100, ErrorMessage = "Name must be between 3 and 100 characters", MinimumLength = 3)]
        public string Name { get; set; }
        //Description
        [Required]
        [Column(TypeName = "text")]
        [StringLength(100, ErrorMessage = "The Description must be between 3 and 100 characters.", MinimumLength = 3)]
        public string Description { get; set; }
        //Quantity
        [Required]
        public int Quantity { get; set; }
        //Manufacturer
        [StringLength(100, ErrorMessage = "Manufacturer must be between 3 and 100 characters", MinimumLength = 3)]
        public string Manufacturer { get; set; }
        //SN - Serial Number
        [StringLength(50, ErrorMessage = "The SN must be between 1 and 50 characters.", MinimumLength = 1)]
        public string SN { get; set; }
        //OS - Operating System
        [StringLength(50, ErrorMessage = "OS must be between 5 and 50 characters", MinimumLength = 5)]
        public string OS { get; set; }
        //Price
        //[Range(1, 20000)]
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        //Old price
        //[Range(1, 20000)]
        [Column(TypeName = "money")]
        [Display(Name = "Old price")]
        public decimal? OldPrice { get; set; }
        //UserID
        public int? UserID { get; set; }
        //PlaceID
        public int? PlaceID { get; set; }
        //FullPrice
       // [Range(1, 200000)]
        [Column(TypeName = "money")]
        [Display(Name = "Full price")]
        public decimal? FullPrice { get; set; }
        //Savings
        [Column(TypeName = "money")]
       // [Range(1, 20000)]
        public decimal? Savings { get; set; }
        public DateTime? Date { get; set; }

    }
}