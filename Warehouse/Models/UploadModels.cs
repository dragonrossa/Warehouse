using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class UploadModels
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Data { get; set; }
        [MaxLength(2130702268)]
        public byte[] test { get; set; }
    }
}