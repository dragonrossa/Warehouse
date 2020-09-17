using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Helpers
{
    public class SearchIndex
    {
        //User inputs name
        public string Name { get; set; }
        //Laptop
        [Display(Name = "Name")]
        public string LaptopName { get; set; }      
        public int Quantity { get; set; }
        [Display(Name = "Full price")]
        public decimal? FullPrice { get; set; }
        [Display(Name="All products")]
        public int QuantityOfAllProducts { get; set; }

        //Store
        [Display(Name = "Store")]
        public string StoreName { get; set; }
        [Display(Name = "Location")]
        public string StoreLocation { get; set;}
        [Display(Name = "Address")]
        public string StoreAddress { get; set; }

        //Transfer
        [Display(Name = "Name")]
        public string TransferLaptopName { get; set; }
        [Display(Name = "Quantity")]
        public int TransferLaptopQuantity { get; set; }
        [Display(Name = "Store")]
        public string TransferStoreName { get; set; }
    }
}