using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class UserRepository:IUserRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //Username of this user
        public string user(string username)
        {
            var user = username;
            return user;
        }

        //Users list of details
        public UserModels userModels(string user)
        {
            UserModels userModels = (from k in _db.UserModels where k.Mail == user select k).First();
            return userModels;
        }

        //Save this users details after editing

        public UserModels saveUser(UserModels userModels)
        {
            _db.Entry(userModels).State = EntityState.Modified;
            userModels.DateModified = DateTime.Now;
            _db.SaveChanges();
            return userModels;
        }


    }
}