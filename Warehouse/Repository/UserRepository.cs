using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Warehouse.DAL;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Repository
{
    public class UserRepository:IUserRepository
    {
        //Get DB Context

        private WarehouseContext _db = new WarehouseContext();

        //Get PageParameters object

         PageParameters pages = new PageParameters();


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

        //Part for search and paging

        

        public async Task<IPagedList<UserModels>> AscendingByName(int? page)
        {
            var users = await _db.UserModels.OrderBy(x => x.Name).ToListAsync();
            return users.ToPagedList(pages.pageNumber(page), pages.pageSize);
       
        }

        public async Task<IPagedList<UserModels>> DescendingByName(int? page)
        {
           
             var users = await _db.UserModels.OrderByDescending(x => x.Name).ToListAsync();
             return users.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }

        public async Task<IPagedList<UserModels>> AscendingByLastName(int? page)
        {
            var users = await _db.UserModels.OrderBy(x => x.LastName).ToListAsync();
            return users.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }

        public async Task<IPagedList<UserModels>> DescendingByLastName(int? page)
        {
          
            var users = await _db.UserModels.OrderByDescending(x => x.LastName).ToListAsync();
            return users.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }



        public async Task<IPagedList<UserModels>> AscendingByUserName(int? page)
        {
            
             var users = await _db.UserModels.OrderBy(x => x.Mail).ToListAsync();
             return users.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }

        public async Task<IPagedList<UserModels>> DescendingByUserName(int? page)
        {
           
            var users =  await _db.UserModels.OrderByDescending(x => x.Mail).ToListAsync();
            return users.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }


    }
}