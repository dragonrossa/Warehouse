using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Warehouse.Models;

namespace Warehouse.Models
{
    interface IEquipment
    {

        [Key]
        int ID { get; set; }

        string Name { get; set; }

        string Details { get; set; }
        int Quantity { get; set; }
       
    }


    interface IElement<T>
    {
        List<T> Child { get; }
        List<T> Ascending { get; }
        List<T> Descending { get; }
    }

 

    interface ISupplier
    {
        int ID { get; set; }
        string SupplierAddress { get; set; }

        string SupplierLocation { get; set; }
    }


    public class ProcessorModels: IEquipment, IElement<ProcessorModels>, ISupplier
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [Key]
        public virtual int ID { get; set; }
        public virtual int Quantity { get; set; }
        public virtual string Name { get; set; }
        public virtual string Details { get; set; }
        public virtual string SupplierAddress { get; set; }
        public virtual string SupplierLocation { get; set; }

        [NotMapped]
        public List<ProcessorModels> Child { 
            get 
            {
                return 
                    (from i in _db.ProccessorModels
                        select i).ToList(); 
            } 
        }

        [NotMapped]
        public List<ProcessorModels> Ascending
        {
            get
            {
                //Ascening list
                return _db.ProccessorModels.OrderBy(x => x.ID).ToList();
            }
         }

        [NotMapped]
        public List<ProcessorModels> Descending
        {
            get
            {
                //Descening list
                return _db.ProccessorModels.OrderByDescending(x => x.ID).ToList();
                
            }
        }

    }
}