using Microsoft.EntityFrameworkCore;
using ProductAPIDB.Models;

namespace ProductAPIDB.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        
    }
}
