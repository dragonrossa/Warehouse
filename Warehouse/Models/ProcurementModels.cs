using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class ProcurementModels
    {

        [Key]
        public int ID { get; set; }
        [Display(Name = "Computer")]
        public string Computer { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Invoice")]
        public string InvoiceNo { get; set; }
        [Display(Name = "Date")]
        public DateTime RequestDate { get; set; }
    }
}