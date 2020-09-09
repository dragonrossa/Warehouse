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
        [Display(Name = "Laptop ID")]
        public int LaptopID { get; set; }
        [Display(Name = "Laptop name")]
        public string LaptopName { get; set; }
        [Display(Name = "Laptop quantity")]
        public int LaptopQuantity { get; set; }
        [Display(Name = "Store ID")]
        public int StoreID { get; set; }
        public DateTime? Date { get; set; }
    }
}