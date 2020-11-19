using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class AdminRepository:IAdminRepository
    {
        public ApplicationDbContext _db = new ApplicationDbContext();

        //Get DB
        public ApplicationDbContext Data(ApplicationDbContext _db)
        {
            
            this._db = _db;
            return _db;
         }

        //Return list of users
        public List<UserModels> users()
        {
            return (from u in _db.UserModels
                    select u).ToList();
        }

        //Find exact user
        public UserModels findUser(int id)
        {
            var user = (from u in _db.UserModels
                        where u.ID == id
                        select u).FirstOrDefault();
            return user;
        }

        // Current role for some user
        public string currentRole(UserModels user)
        {
            return (from r in _db.RolesModels
                    join a in _db.AdminModels
                    on r.ID equals a.RoleID
                    where a.Username == user.UserName
                    select r.Role).SingleOrDefault();
        }

        //Dropdown with list of possible roles
        public object listOfRoles()
        {
            return _db.RolesModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Role,
                Value = u.ID.ToString()
            }).ToList();

        }

        //Logs

        public LogModels log6(string userUsername, object tempdataCurrentRole)
        {
            LogModels log = new LogModels
            {
                Type = "6",
                Description = "New change was made for user " + userUsername + " on date " + DateTime.Now + " for role " + tempdataCurrentRole + ".",
                Date = DateTime.Now
            };

            _db.LogModels.Add(log);
            _db.SaveChanges();
            return log;
        }

        //Find user by username

        public string findUsername(AdminModels admin)
        {
            return (from u in _db.AdminModels where u.Username == admin.Username select u.Username).FirstOrDefault();
        }

        //Get user object
        public AdminModels user1(AdminModels admin)
        {
            return (from u in _db.AdminModels where u.Username == admin.Username select u).FirstOrDefault();
        }

        //Find current role for some user
        public string getCurrentRole(int userRoleID)
        {
            return (from r in _db.RolesModels where r.ID == userRoleID select r.Role).FirstOrDefault();
        }


        //Find Access for user
        public List<AdminModels> access(string username)
        {
            return (from a in _db.AdminModels where a.Username == username select a).ToList();
        }


        //Create list of access for users who dont have record in AdminModels

        public AdminModels adminListOfAccess(string username)
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
            _db.SaveChanges();
            return admin;
        }


        //Find user in AdminModels
        public AdminModels adminUser(int userID)
        {
            return (from u in _db.AdminModels where u.ID == userID select u).FirstOrDefault();
        }


        //Create new log
        public string log7(FormCollection form, int userID, string adminUserIDUsername)
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


            bool a = access == "true,false" ? adminUser(userID).Access = Convert.ToBoolean("true") : adminUser(userID).Access = Convert.ToBoolean("false");
            bool b = laptopAccess == "true,false" ? adminUser(userID).LaptopAccess = Convert.ToBoolean("true") : adminUser(userID).LaptopAccess = Convert.ToBoolean("false");
            bool c = logAccess == "true,false" ? adminUser(userID).LogAccess = Convert.ToBoolean("true") : adminUser(userID).LogAccess = Convert.ToBoolean("false");
            bool d = searchAccess == "true,false" ? adminUser(userID).SearchAccess = Convert.ToBoolean("true") : adminUser(userID).SearchAccess = Convert.ToBoolean("false");
            bool e = storeAccess == "true,false" ? adminUser(userID).StoreAccess = Convert.ToBoolean("true") : adminUser(userID).StoreAccess = Convert.ToBoolean("false");
            bool f = transferAccess == "true,false" ? adminUser(userID).TransferAccess = Convert.ToBoolean("true") : adminUser(userID).TransferAccess = Convert.ToBoolean("false");
            bool g = taskAccess == "true,false" ? adminUser(userID).TaskAccess = Convert.ToBoolean("true") : adminUser(userID).TaskAccess = Convert.ToBoolean("false");
            bool h = supplierAccess == "true,false" ? adminUser(userID).SupplierAccess = Convert.ToBoolean("true") : adminUser(userID).SupplierAccess = Convert.ToBoolean("false");
            bool j = procurementAccess == "true,false" ? adminUser(userID).ProcurementAccess = Convert.ToBoolean("true") : adminUser(userID).ProcurementAccess = Convert.ToBoolean("false");

            _db.SaveChanges();

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
                _db.SaveChanges();

            }

            return "Done";

        }

        //Save DB
        public object SaveData()
        {
           
            return _db.SaveChanges();
        }

    }
}