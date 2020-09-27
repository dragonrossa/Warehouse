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
        [StringLength(80, ErrorMessage = "Address must be between 1 and 80 characters.",MinimumLength=1)]

        public string Address { get; set; }
        [StringLength(60, ErrorMessage = "Hometown must be between 1 and 60 characters",MinimumLength=1)]

        public string Hometown { get; set; }
        //[RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$)")] //check if zipcode is 5 or 4 letters
        [StringLength(20, ErrorMessage = "Zipcode must be between 1 and 20 characters",MinimumLength=1)]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }
        [StringLength(30, ErrorMessage = "Country must be between 1 and 30 characters",MinimumLength =1)]

        public string Country { get; set; }
        [StringLength(40, ErrorMessage = "Mail must be between 1 and 40 characters",MinimumLength=1)]

        public string Mail { get; set; }

        [StringLength(30, ErrorMessage = "Telephone must be between 1 and 30 characters",MinimumLength=1)]

        public string Telephone { get; set; }
        [Display(Name = "Date modified")]
        public DateTime? DateModified { get; set; }
    }
}