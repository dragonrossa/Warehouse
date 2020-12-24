using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Helpers;

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

        [Display(Name = "Laptop access")]
        public bool LaptopAccess { get; set; }

        [Display(Name = "Log access")]
        public bool LogAccess { get; set; }

        [Display(Name = "Search access")]
        public bool SearchAccess { get; set; }

        [Display(Name = "Store access")]
        public bool StoreAccess { get; set; }

        [Display(Name = "Transfer access")]
        public bool TransferAccess { get; set; }

        [Display(Name = "Task access")]
        public bool TaskAccess { get; set; }

        [Display(Name = "Supplier access")]
        public bool SupplierAccess { get; set; }

        [Display(Name = "Procurement access")]
        public bool ProcurementAccess { get; set; }

        //Access list for user

        public IEnumerable<AdminModels> access { get; set; }

        //Interface implementation


        //Constructor for Admin Models
        //public AdminModels(int ID, int RoleID, string Username, bool Access)
        //{
        //    this.ID = ID;
        //    this.RoleID = RoleID;
        //    this.Username= Username;
        //    this.Access = Access;
        //}


    }
}