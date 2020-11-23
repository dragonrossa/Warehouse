using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface IUserRepository
    {
        //Username of this user
        string user(string username);
        //Users list of details
        UserModels userModels(string user);
        //Save this users details after editing
        UserModels saveUser(UserModels userModels);
    }
}