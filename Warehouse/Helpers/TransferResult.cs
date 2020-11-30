using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Helpers
{
    public class TransferResult: ListOrderbyTransfer<TransferResult>
    {
        public string StoreName { get; set; } 
        public string LaptopName { get; set; } 
        public int LaptopQuantity { get; set; }
        public IEnumerable<TransferResult> result { get; set; }

        TransferRepository repository = new TransferRepository();

        [NotMapped]
        public List<TransferResult> AscendingByName
        {
            get
            {
                return repository.storeResult().OrderBy(x => x.LaptopName).ToList();
            }
        }
        [NotMapped]
        public List<TransferResult> DescendingByName
        {
            get
            {
                return repository.storeResult().OrderByDescending(x => x.LaptopName).ToList();
            }
        }

        [NotMapped]
        public List<TransferResult> AscendingByQuantity
        {
            get
            {
                return repository.storeResult().OrderBy(x => x.LaptopQuantity).ToList();
            }
        }
        [NotMapped]
        public List<TransferResult> DescendingByQuantity
        {
            get
            {
                return repository.storeResult().OrderByDescending(x => x.LaptopQuantity).ToList();
            }
        }
        [NotMapped]
        public List<TransferResult> AscendingByPlace
        {
            get
            {
                return repository.storeResult().OrderBy(x => x.StoreName).ToList();
            }
        }
        [NotMapped]
        public List<TransferResult> DescendingByPlace
        {
            get
            {
                return repository.storeResult().OrderByDescending(x => x.StoreName).ToList();
            }
        }
    }
}