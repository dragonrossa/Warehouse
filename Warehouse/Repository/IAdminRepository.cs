using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Repository
{
    //Repo for Admin
    public interface IAdminRepository
    {
        //Get DB
        WarehouseContext Data(WarehouseContext _db);
        //Return list of users
        Task<List<UserModels>> users();
        //Find exact user
        Task<UserModels> findUser(int id);
        // Current role for some user
        Task<string> currentRole(UserModels user);
        //Dropdown with list of possible roles
        Task<object> listOfRoles();
        //Logs
        Task<LogModels> log6(string userUsername, object tempdataCurrentRole);
        //Find user by username
        Task<string> findUsername(AdminModels admin);
        //Get user object
        Task<AdminModels> user1(AdminModels admin);
        //Find current role for some user
        Task<string> getCurrentRole(int userRoleID);
        //Find Access for user
        Task<List<AdminModels>> access(string username);
        //Create list of access for users who dont have record in AdminModels
        Task<AdminModels> adminListOfAccess(string username);
        //Find user in AdminModels
        Task<AdminModels> adminUser(int userID);
        //Create new log
        Task<string> log7(FormCollection form, int userID, string adminUserIDUsername);
        //Save db
        Task<object> SaveData();

    }
}