using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class LaptopModels:IEquipment, IElement<LaptopModels>
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //ID
        [Key]
        public int ID { get; set; }
        //Name
        [Required]
        [StringLength(100, ErrorMessage = "Name must be between 3 and 100 characters", MinimumLength = 3)]
        public string Name { get; set; }
        //Description
        [Required]
        [Column(TypeName = "text")]
        //[StringLength(100, ErrorMessage = "The Description must be between 3 and 100 characters.", MinimumLength = 3)]
        //public string Description { get; set; }
        [StringLength(100, ErrorMessage = "The Description must be between 3 and 100 characters.", MinimumLength = 3)]
        public virtual string Details { get; set; }
        //Quantity
        [Required]
        public int Quantity { get; set; }
        //Manufacturer
        [StringLength(100, ErrorMessage = "Manufacturer must be between 1 and 100 characters", MinimumLength = 1)]
        public string Manufacturer { get; set; }
        //SN - Serial Number
        [StringLength(50, ErrorMessage = "The SN must be between 1 and 50 characters.", MinimumLength = 1)]
        public string SN { get; set; }
        //OS - Operating System
        [StringLength(50, ErrorMessage = "OS must be between 5 and 50 characters", MinimumLength = 5)]
        public string OS { get; set; }
        //Price
        //[Range(1, 20000)]
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        //Old price
        //[Range(1, 20000)]
        [Column(TypeName = "money")]
        [Display(Name = "Old price")]
        public decimal? OldPrice { get; set; }
        //UserID
        [NotMapped]
        public int? UserID { get; set; }
        //PlaceID
        [NotMapped]
        public int? PlaceID { get; set; }
        //FullPrice
        // [Range(1, 200000)]
        [Column(TypeName = "money")]
        [Display(Name = "Full price")]
        public decimal? FullPrice { get; set; }
        //Savings
        [Column(TypeName = "money")]
       // [Range(1, 20000)]
        public decimal? Savings { get; set; }
        public DateTime? Date { get; set; }

        public IEnumerable<LaptopModels> laptop { get; set;}

        [NotMapped]
        public List<LaptopModels> Child
        {
            get
            {
                return
                    (from i in _db.LaptopModels
                     select i).ToList();
            }
        }

        [NotMapped]
        public LaptopModels lastInput
        {
            get
            {
                return (from k in _db.LaptopModels
                        select k)
                                .OrderByDescending(k => k.ID)
                                .FirstOrDefault();
            }
        }


        [NotMapped]
        public List<LaptopModels> Ascending
        {
            get
            {
                //Ascening list
                return _db.LaptopModels.OrderBy(x => x.ID).ToList();
            }
        }

        [NotMapped]
        public List<LaptopModels> Descending
        {
            get
            {
                //Descening list
                return _db.LaptopModels.OrderByDescending(x => x.ID).ToList();

            }
        }

        [NotMapped]
        public decimal? maxNumber
        {
            get
            {
                return Child.Sum(d => d.Savings);
            }
        }

        [NotMapped]
        public int sumQuantity
        {
            get
            {
                return Child.Sum(d => d.Quantity);
            }
        }

        [NotMapped]
        public decimal? sumFullPrice
        {
            get
            {
                return Child.Sum(d => d.FullPrice);
            }
        }

    }
}