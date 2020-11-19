using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Repository
{
    //Repo for Admin
    public interface IAdminRepository
    {
        //Get DB
        ApplicationDbContext Data(ApplicationDbContext _db);
        //Return list of users
        List<UserModels> users();
        //Find exact user
        UserModels findUser(int id);
        // Current role for some user
        string currentRole(UserModels user);
        //Dropdown with list of possible roles
        object listOfRoles();
        //Logs
        LogModels log6(string userUsername, object tempdataCurrentRole);
        //Find user by username
        string findUsername(AdminModels admin);
        //Get user object
        AdminModels user1(AdminModels admin);
        //Find current role for some user
        string getCurrentRole(int userRoleID);
        //Find Access for user
        List<AdminModels> access(string username);
        //Create list of access for users who dont have record in AdminModels
        AdminModels adminListOfAccess(string username);
        //Find user in AdminModels
        AdminModels adminUser(int userID);
        //Create new log
        string log7(FormCollection form, int userID, string adminUserIDUsername);

        //Save db
        object SaveData();

    }
}