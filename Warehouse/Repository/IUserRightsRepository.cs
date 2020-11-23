using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface IUserRightsRepository
    {
        //Get user
        AdminModels admin(string username);
    }
}