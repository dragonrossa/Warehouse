using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class LogModels
    {
        //ID
        [Key]
        public int ID { get; set; }
        [Required]
        //Type of log
        public string Type { get; set; }
        [Column(TypeName = "text")]
        //Description
        public string Description { get; set; }
        //Date + time
        public DateTime? Date { get; set; }

        //Custom models needed for Index for Type 0, 1, 2
        public List<LogModels> log { get; set; }
        public List<LogModels> log1 { get; set; }
        public List<LogModels> log2 { get; set; }
        public List<LogModels> log3 { get; set; }
        public List<LogModels> log4 { get; set; }
    }
}