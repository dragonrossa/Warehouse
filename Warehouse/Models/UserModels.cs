using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class UserModels
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [StringLength(80, ErrorMessage = "Address cant have more than 80 letters")]

        public string Address { get; set; }
        [StringLength(60, ErrorMessage = "Hometown cant have more than 60 letters")]

        public string Hometown { get; set; }
        [StringLength(20, ErrorMessage = "Zipcode cant have more than 20 letters")]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }
        [StringLength(30, ErrorMessage = "Country cant have more than 30 letters")]

        public string Country { get; set; }
        [StringLength(40, ErrorMessage = "Mail cant have more than 40 letters")]

        public string Mail { get; set; }

        [StringLength(30, ErrorMessage = "Telephone cant have more than 30 letters")]

        public string Telephone { get; set; }
        [Display(Name = "Date modified")]
        public DateTime? DateModified { get; set; }
    }
}