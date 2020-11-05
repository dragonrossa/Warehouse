using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.UI.WebControls;
using Warehouse.Helpers;


namespace Warehouse.Models
{
    public class LogModels:IElement<LogModels>
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

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

        //Custom models needed for Index for Type 0, 1, 2, 3, 4, 5, 6, 7
        [NotMapped]
        public List<LogModels> log { get; set; }
        [NotMapped]
        public List<LogModels> log1 { get; set; }
        [NotMapped]
        public List<LogModels> log2 { get; set; }
        [NotMapped]
        public List<LogModels> log3 { get; set; }
        [NotMapped]
        public List<LogModels> log4 { get; set; }
        [NotMapped]
        public List<LogModels> log5 { get; set; }
        [NotMapped]
        public List<LogModels> log6 { get; set; }
        [NotMapped]
        public List<LogModels> log7 { get; set; }

        //All logs
        [NotMapped]
        public List<LogModels> Child
        {
            get
            {
                return (from t in _db.LogModels select t).ToList();
            }
        }

        //Logs ordered by Asc

        [NotMapped]
        public List<LogModels> Ascending
        {
            get
            {
                return _db.LogModels.OrderBy(x => x.ID).ToList();
            }
        }


        //Logs ordered by Desc

        [NotMapped]
        public List<LogModels> Descending
        {
            get
            {
                return _db.LogModels.OrderByDescending(x => x.ID).ToList();
            }
        }

      
    }
}