using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class AdminModels
    {
        [Key]
        public int ID { get; set; }

        public int RoleID { get; set; }

        public string Username { get; set; }
        [Display(Name = "Admin access")]
        public bool Access { get; set; }

        public bool LaptopAccess { get; set; }

        public bool LogAccess { get; set; }
        public bool SearchAccess { get; set; }
        public bool StoreAccess { get; set; }
        public bool TransferAccess { get; set; }
 
    }
}