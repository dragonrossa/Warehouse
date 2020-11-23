using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class UserRightsRepository:IUserRightsRepository
    {
        //Get DB context
        public ApplicationDbContext _db = new ApplicationDbContext();

        //Get user
        public AdminModels admin(string username)
        {
            var user = username;
            var adminUser = (from a in _db.AdminModels where a.Username == user select a).FirstOrDefault();
            return adminUser;
        }
    }
}