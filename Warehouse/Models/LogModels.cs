using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.UI.WebControls;
using Warehouse.DAL;
using Warehouse.Helpers;


namespace Warehouse.Models
{
    public class LogModels:IElement<LogModels>, ListOrderByLog<LogModels>
    {
        private WarehouseContext _db = new WarehouseContext();

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
        [DataType(DataType.Date)]
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

        public IEnumerable<LogModels> logs1 { get; set; }

        public IEnumerable<LogModels> logs2 { get; set; }

        public IEnumerable<LogModels> logs3 { get; set; }
        public IEnumerable<LogModels> logs4 { get; set; }

        public IEnumerable<LogModels> logs5 { get; set; }
        public IEnumerable<LogModels> logs6 { get; set; }
        public IEnumerable<LogModels> logs7 { get; set; }

        public IEnumerable<LogModels> logs8 { get; set; }

        //PagedList
        public IPagedList<LogModels> logs10{ get; set; }
        public IPagedList<LogModels> logs20 { get; set; }
        public IPagedList<LogModels> logs30 { get; set; }
        public IPagedList<LogModels> logs40 { get; set; }
        public IPagedList<LogModels> logs50 { get; set; }
        public IPagedList<LogModels> logs60 { get; set; }
        public IPagedList<LogModels> logs70 { get; set; }
        public IPagedList<LogModels> logs80 { get; set; }


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

        //Logs ordered by Desc

        [NotMapped]
        public List<LogModels> AscendingByDate
        {
            get
            {
                return _db.LogModels.OrderBy(x => x.Date).ToList();
            }
        }

        //Logs ordered by Desc

        [NotMapped]
        public List<LogModels> DescendingByDate
        {
            get
            {
                return _db.LogModels.OrderByDescending(x => x.Date).ToList();
            }
        }


    }
}