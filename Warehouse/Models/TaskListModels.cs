using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace Warehouse.Models
{
    public class TaskListModels
    {
        [Key]
        public int ID { get; set; }
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string Details { get; set; }

        public string User { get; set; }
        public bool Status { get; set; }

        [DisplayName("Task Assistant")]

        public string Assistant1 { get; set; }

        [DisplayName("Task Assistant")]
        public string Assistant2 { get; set; }

        [DisplayName("Task Assistant")]
        public string Assistant3 { get; set; }



        
    }
}