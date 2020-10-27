using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [RegularExpression(@"^[1-1000]{1,4}$", ErrorMessage = "Quantity must be between 1 and 1000")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Invoice")]
        public string InvoiceNo { get; set; }
        [Display(Name = "Date")]
        public DateTime RequestDate { get; set; }
    }
}