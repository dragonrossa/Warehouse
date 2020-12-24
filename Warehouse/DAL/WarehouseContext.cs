using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Warehouse.Models;

namespace Warehouse.DAL
{
    public class ApplicationUser : IdentityUser
    {
        public string Hometown { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class WarehouseContext : IdentityDbContext<ApplicationUser>
    {
        public WarehouseContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Disable initialization of context
            Database.SetInitializer<WarehouseContext>(null);
        }


        public static WarehouseContext Create()
        {
            return new WarehouseContext();
        }

        public virtual DbSet<LaptopModels> LaptopModels { get; set; }
        public virtual DbSet<StoreModels> StoreModels { get; set; }
        public virtual DbSet<TransferModels> TransferModels { get; set; }
        public virtual DbSet<LogModels> LogModels { get; set; }
        public virtual DbSet<UserModels> UserModels { get; set; }
        public virtual DbSet<AdminModels> AdminModels { get; set; }
        public virtual DbSet<RolesModels> RolesModels { get; set; }
        public virtual DbSet<TaskListModels> TaskListModels { get; set; }
        public virtual DbSet<UploadModels> UploadModels { get; set; }
        public virtual DbSet<SupplierModels> SupplierModels { get; set; }
        public virtual DbSet<ComputerListModels> ComputerListModels { get; set; }
        public virtual DbSet<ProcurementModels> ProcurementModels { get; set; }
        public virtual DbSet<ProcessorModels> ProccessorModels { get; set; }
        public virtual DbSet<GlobalErrorsModels> GlobalErrorsModels { get; set; }

    }

   
}