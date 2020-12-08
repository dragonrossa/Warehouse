using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Warehouse.Helpers;

namespace Warehouse.Models
{
    public class UserModels : ListOrderByUser<UserModels>
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [RegularExpression(@"^[a-zA-Z.]{2,80}$", ErrorMessage = "Address must have min 2 and max 80 letters")]

        public string Address { get; set; }
        [RegularExpression(@"^[a-zA-Z.]{2,60}$", ErrorMessage = "Hometown must have min 2 and max 60 letters")]

        public string Hometown { get; set; }
        [RegularExpression(@"\d{5}$", ErrorMessage = "Zipcode has 5 digits")]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }
        [RegularExpression(@"^[a-zA-Z.]{2,30}$", ErrorMessage = "Country must have min 2 and max 30 letters")]

        public string Country { get; set; }
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "This is not valid email address!")]

        public string Mail { get; set; }

        [RegularExpression(@"\d{9,10}$", ErrorMessage = "Telephone number can have 9 or 10 digits")]

        public string Telephone { get; set; }
        [Display(Name = "Date modified")]
        public DateTime? DateModified { get; set; }

        public IEnumerable<UserModels> users { get; set; }


        [NotMapped]
        public List<UserModels> AscendingByName
        {
            get
            {
                return _db.UserModels.OrderBy(x => x.Name).ToList();
            }
        }

        [NotMapped]
        public List<UserModels> DescendingByName
        {
            get
            {
                return _db.UserModels.OrderByDescending(x => x.Name).ToList();
            }
        }

        [NotMapped]
        public List<UserModels> AscendingByLastName
        {
            get
            {
                return _db.UserModels.OrderBy(x => x.LastName).ToList();
            }
        }

        [NotMapped]
        public List<UserModels> DescendingByLastName
        {
            get
            {
                return _db.UserModels.OrderByDescending(x => x.LastName).ToList();
            }
        }



        [NotMapped]
        public List<UserModels> AscendingByUserName
        {
            get
            {
                return _db.UserModels.OrderBy(x => x.Mail).ToList();
            }
        }

        [NotMapped]
        public List<UserModels> DescendingByUserName
        {
            get
            {
                return _db.UserModels.OrderByDescending(x => x.Mail).ToList();
            }
        }




    }
}