using System;
using System.Collections.Generic;
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

        public bool Access { get; set; }

    }
}