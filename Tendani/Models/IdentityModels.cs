using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Tendani.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int EmployeeNo { get; set; }
        public string Office { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public int UserType { get; set; }

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

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<Assertion> Assertions { get; set; }

        public DbSet<ClientTool> ClientTools { get; set; }

        public DbSet<Industry> Industries { get; set; }

        public DbSet<SignificantAccount> SignificantAccounts { get; set; }

        public DbSet<Solution> Solutions { get; set; }

        public DbSet<ToolUsed> ToolUseds { get; set; }

        public System.Data.Entity.DbSet<Tendani.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}