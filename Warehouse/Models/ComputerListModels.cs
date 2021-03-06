﻿using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.DAL;
using Warehouse.Helpers;

namespace Warehouse.Models
{
    public class ComputerListModels : IElement<ComputerListModels>, ListOrderByComputerList<ComputerListModels>
    {
        private WarehouseContext _db = new WarehouseContext();

        [Key]
        public int ID { get; set; }
        //Name - required
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9 .-]{1,50}$", ErrorMessage = "Name must have min 1 and max 50 letters")]
        public string Name { get; set; }
        public string SupplierName { get; set; }
        public int SupplierID { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public IEnumerable<SelectListItem> computers { get; set; }
        public IEnumerable<SelectListItem> suppliers { get; set; }
        public IEnumerable<ComputerListModels> computersList { get; set; }
        //PagedList
        public IPagedList<ComputerListModels> computerList { get; set; }
        public IPagedList<SupplierModels> supplierList { get; set; }

        [NotMapped]
        public List<ComputerListModels> Child
        {
            get
            {
                return
                    (from i in _db.ComputerListModels
                     select i).ToList();
            }
        }

        [NotMapped]
        public List<ComputerListModels> Ascending
        {
            get
            {
                return _db.ComputerListModels.ToList().OrderBy(u => u.ID).Select(u => u).ToList();
            }
        }

        [NotMapped]
        public List<ComputerListModels> Descending
        {
            get
            {
               return  _db.ComputerListModels.ToList().OrderByDescending(u => u.ID).Select(u => u).ToList();
               
            }
        }

        [NotMapped]
        public List<ComputerListModels> AscendingByName
        {
            get
            {
                return _db.ComputerListModels.OrderBy(u => u.Name).Select(u => u).ToList();

            }
        }

        [NotMapped]
        public List<ComputerListModels> DescendingByName
        {
            get
            {
                return _db.ComputerListModels.OrderByDescending(u => u.Name).Select(u => u).ToList();

            }
        }
    }
}