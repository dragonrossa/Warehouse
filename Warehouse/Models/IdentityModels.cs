using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Warehouse.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

      
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
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
    }
}