using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Warehouse.DAL;
using Warehouse.Helpers;

namespace Warehouse.Models
{
    
    public class LaptopModels:IEquipment, ListOrderByLaptop<LaptopModels>
    {
        private WarehouseContext _db = new WarehouseContext();

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
        [Column(TypeName = "money")]
        [Display(Name = "Full price")]
        public decimal? FullPrice { get; set; }
        //FullPriceWithPDV
        [Column(TypeName = "money")]
        [Display(Name = "Full price with PDV")]
        public decimal? FullPriceWithPDV { get; set; }
        //PDV
        [Column(TypeName = "money")]
        [Display(Name = "PDV")]
        public decimal? PDV { get; set; }
        //Savings
        [Column(TypeName = "money")]
        public decimal? Savings { get; set; }
        [DataType(DataType.Date)]
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
        public List<LaptopModels> AscendingByName
        {
            get
            {
                //Ascening list
                return _db.LaptopModels.OrderBy(x => x.Name).ToList();
            }
        }

        [NotMapped]
        public List<LaptopModels> DescendingByName
        {
            get
            {
                //Descening list
                return _db.LaptopModels.OrderByDescending(x => x.Name).ToList();

            }
        }

        [NotMapped]
        public List<LaptopModels> AscendingByQuantity
        {
            get
            {
                //Ascening list
                return _db.LaptopModels.OrderBy(x => x.Quantity).ToList();
            }
        }

        [NotMapped]
        public List<LaptopModels> DescendingByQuantity
        {
            get
            {
                //Descening list
                return _db.LaptopModels.OrderByDescending(x => x.Quantity).ToList();

            }
        }

        [NotMapped]
        public List<LaptopModels> AscendingByPrice
        {
            get
            {
                //Ascening list
                return _db.LaptopModels.OrderBy(x => x.Price).ToList();
            }
        }

        [NotMapped]
        public List<LaptopModels> DescendingByPrice
        {
            get
            {
                //Descening list
                return _db.LaptopModels.OrderByDescending(x => x.Price).ToList();

            }
        }

        [NotMapped]
        public List<LaptopModels> AscendingByFullPrice
        {
            get
            {
                //Ascening list
                return _db.LaptopModels.OrderBy(x => x.FullPrice).ToList();
            }
        }

        [NotMapped]
        public List<LaptopModels> DescendingByFullPrice
        {
            get
            {
                //Descening list
                return _db.LaptopModels.OrderByDescending(x => x.FullPrice).ToList();

            }
        }  


      
        [NotMapped]
        public List<LaptopModels> AscendingByOS
        {
            get
            {
                return _db.LaptopModels.OrderBy(x => x.OS).ToList();
            }
        }

        [NotMapped]
        public List<LaptopModels> DescendingByOS
        {
            get
            {
                return _db.LaptopModels.OrderByDescending(x => x.OS).ToList();
            }
        }

    }
}