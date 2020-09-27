using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class RolesModels
    {
            [Key]
            public int ID { get; set; }
            [StringLength(50, ErrorMessage = "Role must be between 1 and 50 characters", MinimumLength = 1)]
            public string Role { get; set; }
        
    }
}