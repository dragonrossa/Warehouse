using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Warehouse.Helpers;

namespace Warehouse.Models
{
    public class SupplierModels : IElement<SupplierModels>
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
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

        [NotMapped]
        public List<SupplierModels> Child
        {
            get
            {
                return _db.SupplierModels.Select(u=>u).ToList();
            }
        }

        [NotMapped]
        public List<SupplierModels> Ascending
        {
            get
            {
                return _db.SupplierModels.OrderBy(u => u.ID).Select(u => u).ToList();
            }
        }

        [NotMapped]
        public List<SupplierModels> Descending
        {
            get
            {
                return _db.SupplierModels.OrderByDescending(u => u.ID).Select(u => u).ToList();

            }
        }
    }
}