using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public string SupplierName { get; set; }
        public IEnumerable<SelectListItem> computers { get; set; }
        public int SupplierID { get; set; }
        public DateTime? Date { get; set; }
        //[NotMapped]
        public IEnumerable<SelectListItem> suppliers { get; set; }
    }
}