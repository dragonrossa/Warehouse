using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Helpers
{
    public class TransferResult: ListOrderbyTransfer<TransferResult>
    {
        public string StoreName { get; set; } 
        public string LaptopName { get; set; } 
        public int LaptopQuantity { get; set; }
        public IEnumerable<TransferResult> result { get; set; }

        [NotMapped]
        public List<TransferResult> AscendingByName
        {
            get
            {
                return result.OrderBy(x => x.LaptopName).ToList();
            }
        }
        [NotMapped]
        public List<TransferResult> DescendingByName
        {
            get
            {
                return result.OrderByDescending(x => x.LaptopName).ToList();
            }
        }

        [NotMapped]
        public List<TransferResult> AscendingByQuantity
        {
            get
            {
                return result.OrderBy(x => x.LaptopQuantity).ToList();
            }
        }
        [NotMapped]
        public List<TransferResult> DescendingByQuantity
        {
            get
            {
                return result.OrderByDescending(x => x.LaptopQuantity).ToList();
            }
        }
        [NotMapped]
        public List<TransferResult> AscendingByPlace
        {
            get
            {
                return result.OrderBy(x => x.StoreName).ToList();
            }
        }
        [NotMapped]
        public List<TransferResult> DescendingByPlace
        {
            get
            {
                return result.OrderByDescending(x => x.StoreName).ToList();
            }
        }
    }
}