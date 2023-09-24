using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedMango_Api.Models;

namespace RedMango_Api.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
