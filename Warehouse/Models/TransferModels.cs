using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class TransferModels
    {
        [Key]
        public int ID { get; set; }
        public int LaptopID { get; set; }
        public string LaptopName { get; set; }
        public int LaptopQuantity { get; set; }
        public int StoreID { get; set; }
    }
}