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
        public int QuantityOfAllProducts { get; set; }

    }
}