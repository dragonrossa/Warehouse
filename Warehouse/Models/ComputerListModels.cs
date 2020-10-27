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
        [RegularExpression(@"^[a-zA-Z0-9 .]{1,50}$", ErrorMessage = "Name must have min 1 and max 50 letters")]
        public string Name { get; set; }
        public string SupplierName { get; set; }

        public int SupplierID { get; set; }
        public DateTime? Date { get; set; }
        public string suppliersSele { get; set; }

        public IEnumerable<SelectListItem> computers { get; set; }
        public IEnumerable<SelectListItem> suppliers { get; set; }
        public IEnumerable<ComputerListModels> computersList { get; set; }
    }
}