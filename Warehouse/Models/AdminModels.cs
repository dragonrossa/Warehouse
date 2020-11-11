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
        private ApplicationDbContext _db = new ApplicationDbContext();

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

        public bool TaskAccess { get; set; }

        public bool SupplierAccess { get; set; }

        public bool ProcurementAccess { get; set; }

        public IEnumerable<AdminModels> access { get; set; }

        //Interface implementation

        //[NotMapped]
        //public List<AdminModels> Child
        //{
        //    get
        //    {
        //        return (from k in _db.AdminModels select k).ToList();
        //    }
        //}

        ////Interface implementation

        //[NotMapped]
        //public List<AdminModels> Ascending
        //{
        //    get
        //    {
        //        return _db.AdminModels.OrderBy(x => x.ID).ToList();
        //    }
        //}

        ////Interface implementation

        //[NotMapped]
        //public List<AdminModels> Descending
        //{
        //    get
        //    {
        //        return _db.AdminModels.OrderByDescending(x => x.ID).ToList();
        //    }
        //}

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