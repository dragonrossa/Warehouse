using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
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
        void getInfo();

    }



    interface IElement<T>
    {
        List<T> Child { get; }
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
                return (from i in _db.ProccessorModels select i).ToList(); 
            } }

        void IEquipment.getInfo()
        {
            
         List<ProcessorModels> obj = (from i in _db.ProccessorModels select i).ToList();
         return;
        }

    }
}