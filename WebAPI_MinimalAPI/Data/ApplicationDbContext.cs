using Microsoft.EntityFrameworkCore;
using WebAPI_MinimalAPI.Models;

namespace WebAPI_MinimalAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Shirt> Shirts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //data seeding
            modelBuilder.Entity<Shirt>().HasData(
                new Shirt { ShirtId = 1, Brand = "V Brand", Color = "Yellow", Gender = "women", Price = 30, Size = 6 },
                new Shirt { ShirtId = 2, Brand = "V Brand", Color = "Blue", Gender = "women", Price = 30, Size = 7 },
                new Shirt { ShirtId = 3, Brand = "W Brand", Color = "Purple", Gender = "women", Price = 30, Size = 7 },
                new Shirt { ShirtId = 4, Brand = "W Brand", Color = "Black", Gender = "men", Price = 30, Size = 10 },
                new Shirt { ShirtId = 5, Brand = "Y Brand", Color = "White", Gender = "women", Price = 10, Size = 6 }
            );
        }
    }
}
