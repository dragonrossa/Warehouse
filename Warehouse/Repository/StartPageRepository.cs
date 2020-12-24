using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class StartPageRepository:IStartPageRepository
    {
      
        private WarehouseContext _db = new WarehouseContext();

        //Get user info
        public UserModels user(string username)
        {
            var userName = username;
            var user = (from u in _db.UserModels where u.UserName == userName select u).FirstOrDefault();
            return user;
        }
    }
}