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
        [StringLength(50, ErrorMessage = "Name must be between 1 and 50 letters", MinimumLength = 1)]
        [Display(Name ="Supplier")]
        public string SupplierName { get; set; }
        //Location - not required
        public string Location { get; set; }
      
        public DateTime? Date { get; set; }
        public IEnumerable<SupplierModels> suppliers { get; set; }
    }
}