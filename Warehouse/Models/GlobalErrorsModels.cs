using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class GlobalErrorsModels
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
    }
}