using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApiGraphQL.Models;

namespace WebApiGraphQL.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
