using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Helpers;
using System.Threading.Tasks;
using Warehouse.DAL;

namespace Warehouse.Repository
{
    public class AdminRepository: DatabaseRepository, IAdminRepository
    {
        public WarehouseContext _db = new WarehouseContext();


        //public WarehouseContext Data1()
        //{
        //    WarehouseContext _db1 = new WarehouseContext();
        //    return _db1;
        //}


        //Return list of users
        public async Task<List<UserModels>> users()
        {
            return await(from u in _db.UserModels
                    select u).ToListAsync();
        }

        //Find exact user
        public async Task<UserModels> findUser(int id)
        {
            var user = await (from u in _db.UserModels
                        where u.ID == id
                        select u).FirstOrDefaultAsync();
            return user;
        }

        // Current role for some user
        public async Task<string> currentRole(UserModels user)
        {
            return await (from r in _db.RolesModels
                    join a in _db.AdminModels
                    on r.ID equals a.RoleID
                    where a.Username == user.UserName
                    select r.Role).SingleOrDefaultAsync();
        }

        //Dropdown with list of possible roles
        public async Task<object> listOfRoles()
        {
            return _db.RolesModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Role,
                Value = u.ID.ToString()
            }).ToList();

        }

        //Logs

        public async Task<LogModels> log6(string userUsername, object tempdataCurrentRole)
        {
            LogModels log = new LogModels
            {
                Type = "6",
                Description = "New change was made for user " + userUsername + " on date " + DateTime.Now + " for role " + tempdataCurrentRole + ".",
                Date = DateTime.Now
            };

            _db.LogModels.Add(log);
            await _db.SaveChangesAsync();
            return log;
        }

        //Find user by username

        public async Task<string> findUsername(AdminModels admin)
        {
            return await (from u in _db.AdminModels where u.Username == admin.Username select u.Username).FirstOrDefaultAsync();
        }

        //Get user object
        public async Task<AdminModels> user1(AdminModels admin)
        {
            return await (from u in _db.AdminModels where u.Username == admin.Username select u).FirstOrDefaultAsync();
        }

        //Find current role for some user
        public async Task<string> getCurrentRole(int userRoleID)
        {
            return await (from r in _db.RolesModels where r.ID == userRoleID select r.Role).FirstOrDefaultAsync();
        }


        //Find Access for user
        public async Task<List<AdminModels>> access(string username)
        {
            return await (from a in _db.AdminModels where a.Username == username select a).ToListAsync();
        }


        //Create list of access for users who dont have record in AdminModels

        public async Task<AdminModels> adminListOfAccess(string username)
        {
            AdminModels admin = new AdminModels();
            admin.Username = username;
            admin.Access = false;
            admin.LaptopAccess = false;
            admin.LogAccess = false;
            admin.SearchAccess = false;
            admin.StoreAccess = false;
            admin.TransferAccess = false;
            admin.TaskAccess = false;
            admin.SupplierAccess = false;
            admin.ProcurementAccess = false;
            _db.AdminModels.Add(admin);
            await _db.SaveChangesAsync();
            return admin;
        }


        //Find user in AdminModels
        public async Task<AdminModels> adminUser(int userID)
        {
            return await (from u in _db.AdminModels where u.ID == userID select u).FirstOrDefaultAsync();
        }


        //Create new log
        public async Task<string> log7(FormCollection form, int userID, string adminUserIDUsername)
        {

            //Get info from from
            string access = form["item.Access"];
            string laptopAccess = form["item.LaptopAccess"];
            string logAccess = form["item.LogAccess"];
            string searchAccess = form["item.SearchAccess"];
            string storeAccess = form["item.StoreAccess"];
            string transferAccess = form["item.TransferAccess"];
            string taskAccess = form["item.TaskAccess"];
            string supplierAccess = form["item.SupplierAccess"];
            string procurementAccess = form["item.ProcurementAccess"];

            //Check if true or false for every of them and save changes

            var acc = await adminUser(userID);


            bool a = access == "true,false" ? acc.Access = Convert.ToBoolean("true") : acc.Access = Convert.ToBoolean("false");
            bool b = laptopAccess == "true,false" ? acc.LaptopAccess = Convert.ToBoolean("true") : acc.LaptopAccess = Convert.ToBoolean("false");
            bool c = logAccess == "true,false" ? acc.LogAccess = Convert.ToBoolean("true") : acc.LogAccess = Convert.ToBoolean("false");
            bool d = searchAccess == "true,false" ? acc.SearchAccess = Convert.ToBoolean("true") : acc.SearchAccess = Convert.ToBoolean("false");
            bool e = storeAccess == "true,false" ? acc.StoreAccess = Convert.ToBoolean("true") : acc.StoreAccess = Convert.ToBoolean("false");
            bool f = transferAccess == "true,false" ? acc.TransferAccess = Convert.ToBoolean("true") : acc.TransferAccess = Convert.ToBoolean("false");
            bool g = taskAccess == "true,false" ? acc.TaskAccess = Convert.ToBoolean("true") : acc.TaskAccess = Convert.ToBoolean("false");
            bool h = supplierAccess == "true,false" ? acc.SupplierAccess = Convert.ToBoolean("true") : acc.SupplierAccess = Convert.ToBoolean("false");
            bool j = procurementAccess == "true,false" ? acc.ProcurementAccess = Convert.ToBoolean("true") : acc.ProcurementAccess = Convert.ToBoolean("false");

            await _db.SaveChangesAsync();

            string[] userAccess = { "Admin access", "Laptop access", " Log access", "Search access", "Store access", "Transfer access", "Task access", "Supplier access", "Procurement access" };

            string[] rights = { Convert.ToString(a), Convert.ToString(b), Convert.ToString(c), Convert.ToString(d), Convert.ToString(e),
                Convert.ToString(f), Convert.ToString(g), Convert.ToString(h), Convert.ToString(j)};


            // Create log for changes

            for (int i = 0; i < userAccess.Length; i++)
            {

                LogModels log = new LogModels
                {
                    Type = "7",
                    Description = "New change was made for user " + adminUserIDUsername + " on date " + DateTime.Now + " granting access:" + rights[i] + " for " + userAccess[i],
                    Date = DateTime.Now
                };

                _db.LogModels.Add(log);
                await _db.SaveChangesAsync();

            }

            return "Done";

        }

        //Save DB
        public async Task<object> SaveData()
        {
           
            return await _db.SaveChangesAsync();
        }

    }
}