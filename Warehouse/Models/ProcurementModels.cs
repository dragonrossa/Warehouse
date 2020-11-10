using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Warehouse.Helpers;

namespace Warehouse.Models
{
    public class ProcurementModels : IElement<ProcurementModels>
    {

        [Key]
        public int ID { get; set; }
        [Display(Name = "Computer")]
        public string Computer { get; set; }
        [RegularExpression(@"^([1-9][0-9]{0,2}|1000)$", ErrorMessage = "Quantity must be between 1 and 1000")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Invoice")]
        public string InvoiceNo { get; set; }
        [Display(Name = "Date")]
        public DateTime RequestDate { get; set; }

         public ApplicationDbContext _db()
        {
            return new ApplicationDbContext();
        }


        [NotMapped]
        public List<ProcurementModels> Child
        {
            get
            {
                return _db().ProcurementModels.Select(u => u).ToList();
            }
        }

        [NotMapped]
        public List<ProcurementModels> Ascending
        {
            get
            {
                return _db().ProcurementModels.OrderBy(x => x.ID).ToList();
            }
        }

        [NotMapped]
        public List<ProcurementModels> Descending
        {
            get
            {
                return _db().ProcurementModels.OrderByDescending(x => x.ID).ToList();
            }
        }
    }
}