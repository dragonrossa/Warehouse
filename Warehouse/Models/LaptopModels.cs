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
        [StringLength(100, ErrorMessage = "Name cant have more than 100 letters")]
        public string Name { get; set; }
        //Description
        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; }
        //Quantity
        [Required]
        public int Quantity { get; set; }
        //Manufacturer
        [StringLength(100, ErrorMessage = "Manufacturer cant have more than 100 letters")]
        public string Manufacturer { get; set; }
        //SN - Serial Number
        [Column(TypeName = "text")]
        public string SN { get; set; }
        //OS - Operating System
        [StringLength(50, ErrorMessage = "OS cant have more than 50 letters")]
        public string OS { get; set; }
        //Price
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        //Old price
        [Column(TypeName = "money")]
        public decimal? OldPrice { get; set; }
        //UserID
        public int? UserID { get; set; }
        //PlaceID
        public int? PlaceID { get; set; }
        //FullPrice
        [Column(TypeName = "money")]
        public decimal? FullPrice { get; set; }

    }
}