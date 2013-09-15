using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WebChat.Models;

namespace WebChat.Data
{
    // You can inherit the base IdentityContext and add your application custom DbSets
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public ApplicationDbContext()
            : base("WebChat")
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}