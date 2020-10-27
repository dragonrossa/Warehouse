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
        [RegularExpression(@"^[a-zA-Z.]{5,50}$", ErrorMessage = "Details must have min 5 and max 50 letters")]
        public string Details { get; set; }

        public string User { get; set; }
        public bool Status { get; set; }

        [DisplayName("Task Assistant")]

        public string Assistant1 { get; set; }

        [DisplayName("Task Assistant")]
        public string Assistant2 { get; set; }

        [DisplayName("Task Assistant")]
        public string Assistant3 { get; set; }
        [DisplayName("Upload file")]
        public string UploadName { get; set; }
        public string ContentType { get; set; }
        [MaxLength(2130702268)]
        public byte[] Data { get; set; }




    }
}