using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Warehouse.DAL;

[assembly: OwinStartup(typeof(Warehouse.Startup))]

namespace Warehouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
