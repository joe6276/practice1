using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductAPIDB.Models;

namespace ProductAPIDB.Data
{
    public class ApplicationAuthContext:IdentityDbContext<User>
    {

        public ApplicationAuthContext(DbContextOptions<ApplicationAuthContext> options):base(options) { }
       

        public DbSet<User> Users {  get; set; } 
    }
}
