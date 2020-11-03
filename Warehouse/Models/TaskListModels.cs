using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Warehouse.Helpers;

namespace Warehouse.Models
{
    public class TaskListModels:IElement<TaskListModels>
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

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

        public List<TaskListModels> Child
        {
            get
            {
                return (from t in _db.TaskListModels select t).ToList();
            }
        }

        public List<TaskListModels> Ascending
        {
            get
            {
                return _db.TaskListModels.OrderBy(x => x.ID).ToList();
            }
        }

        public List<TaskListModels> Descending
        {
            get
            {
                return _db.TaskListModels.OrderByDescending(x => x.ID).ToList();
            }
        }


    }
}