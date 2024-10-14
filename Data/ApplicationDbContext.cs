using Microsoft.EntityFrameworkCore;
using MVC_Demo.Models;

namespace MVC_Demo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity<Category>().HasData(
                
                new Category { Id =1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Drama", DisplayOrder = 3 }

                );

        }
        
    }
}
