using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Helpers
{
    public class SearchIndex
    {
        //User inputs name
        public string Name { get; set; }
        //Laptop
        public string LaptopName { get; set; }      
        public int Quantity { get; set; }
        public decimal? FullPrice { get; set; }
    }
}