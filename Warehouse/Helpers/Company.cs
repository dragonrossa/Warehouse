using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Helpers
{
    public class Company
    {
        //Name
        [Display(Name = "Name")]
        public string Name { get; set; }
        //Street
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Display(Name = "Town")]
        //Town
        public string Town { get; set; }
        [Display(Name = "Zip code")]
        //ZipCode
        public string ZipCode { get; set; }
        [Display(Name = "Country")]
        //Country
        public string Country { get; set; }
        [Display(Name = "OIB")]
        //OIB
        public string OIB { get; set; }
        
    }
}