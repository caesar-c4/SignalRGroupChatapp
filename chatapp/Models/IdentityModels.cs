using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace chatapp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<GroupInfo> GroupInfos { get; set; }
        public DbSet<UserAccess> UserAccesss { get; set; }

        public DbSet<MessageInfo> MessageInfos { get; set; }
        public DbSet<RequestInfo> RequestInfos { get; set; }
        public DbSet<ChatUsers> ChatUsers { get; set; }
        
    }
}