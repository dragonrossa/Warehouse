using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class StartPageRepository:IStartPageRepository
    {
      
        private ApplicationDbContext _db = new ApplicationDbContext();

        //Get user info
        public UserModels user(string username)
        {
            var userName = username;
            var user = (from u in _db.UserModels where u.UserName == userName select u).FirstOrDefault();
            return user;
        }
    }
}