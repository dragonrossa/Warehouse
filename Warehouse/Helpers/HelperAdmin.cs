using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Helpers
{
   // [NotMapped]
    public class HelperAdmin
    {

        private WarehouseContext _db = new WarehouseContext();

        public List<AdminModels> List
        {
            get { 
                return _db.AdminModels.Select(u => u).ToList();
            }
        }

        public List<AdminModels> Ascending
        {
            get
            {
                return _db.AdminModels.OrderBy(u=>u.ID).Select(u => u).ToList();
            }
        }

        public List<AdminModels> Descending
        {
            get
            {
                return _db.AdminModels.OrderBy(u => u.ID).Select(u => u).ToList();
            }
        }


        // public override List<AdminModels> Ascending => throw new NotImplementedException();
        // public override List<AdminModels> Descending => throw new NotImplementedException();

        //[NotMapped]

        //public override void animalSound()
        //{
        //    // The body of animalSound() is provided here
        //    Console.WriteLine("The pig says: wee wee");
        //}

        //public override List<AdminModels> Child
        //{
        //    get {
        //        return (from a in _db.AdminModels select a).ToList();
        //        }
        //}

        //public List<AdminModels> Child
        //{
        //    get
        //    {
        //        return (from k in _db.AdminModels select k).ToList();
        //    }
        //}

        //public new void Child() { /*...*/ }
        //public new void Ascending() { /*...*/ }
        //public new void Descending() { /*...*/ }
    }
}