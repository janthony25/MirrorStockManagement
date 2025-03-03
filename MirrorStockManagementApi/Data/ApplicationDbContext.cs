using Microsoft.EntityFrameworkCore;
using MirrorStockManagementApi.Models;

namespace MirrorStockManagementApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }    
    }
}
