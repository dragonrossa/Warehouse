using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface IStartPageRepository
    {
        //Get user info
        UserModels user(string username);
    }
}