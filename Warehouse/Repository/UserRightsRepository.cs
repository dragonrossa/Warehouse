using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class UserRightsRepository:IUserRightsRepository
    {
        //Get DB context
        public WarehouseContext _db = new WarehouseContext();

        //Get user
        public AdminModels admin(string username)
        {
            var user = username;
            var adminUser = (from a in _db.AdminModels where a.Username == user select a).FirstOrDefault();
            return adminUser;
        }
    }
}