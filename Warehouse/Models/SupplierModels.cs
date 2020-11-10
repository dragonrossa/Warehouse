using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class SupplierModels
    {
        //ID - required
        [Key]
        public int ID { get; set; }
        //Name - required
        [Required]
        [RegularExpression(@"^[a-zA-Z.0-9 ]{1,50}$", ErrorMessage = "Supplier name must have min 1 and max 50 letters")]
        [Display(Name ="Supplier")]
        public string SupplierName { get; set; }
        [RegularExpression(@"^[a-zA-Z.0-9 ]{1,30}$", ErrorMessage = "Location must have min 1 and max 30 letters")]
        //Location - not required
        public string Location { get; set; }
      
        public DateTime? Date { get; set; }
        public IEnumerable<SupplierModels> suppliers { get; set; }
    }
}