using Microsoft.EntityFrameworkCore;
using WebApiRestProductApp.Models;

namespace WebApiRestProductApp.Data
{

    public class ProductDbContext : DbContext
    {

        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 1,
                    Name = "iPhone 14 Pro max",
                    Category = "Phone",
                    ReleaseDate = DateTime.Today,
                    Price = 1299.99
                },
                new Product
                {
                    Id = 2,
                    Name = "Samsung S23 Ultra",
                    Category = "Phone",
                    ReleaseDate = DateTime.Today,
                    Price = 999.99
                }

            );
        }

    }
    
}
