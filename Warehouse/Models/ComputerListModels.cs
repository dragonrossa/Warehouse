using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class ComputerListModels
    {
        [Key]
        public int ID { get; set; }
        //Name - required
        [Required]
        [StringLength(50, ErrorMessage = "Name must be between 1 and 50 letters", MinimumLength = 1)]
        public string Name { get; set; }
        public string SupplierID { get; set; }
        public DateTime? Date { get; set; }
    }
}