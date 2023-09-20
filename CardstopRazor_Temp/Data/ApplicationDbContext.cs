using CardstopRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace CardstopRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Normal Monster", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Effect Monster", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Fusion Monster", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Synchro Monster", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Ritual Monster", DisplayOrder = 5 },
                new Category { Id = 6, Name = "XYZ Monster", DisplayOrder = 6 },
                new Category { Id = 7, Name = "Link Monster", DisplayOrder = 7 },
                new Category { Id = 8, Name = "Normal Trap Card", DisplayOrder = 8 },
                new Category { Id = 9, Name = "Counter Trap Card", DisplayOrder = 9 },
                new Category { Id = 10, Name = "Normal Spell Card", DisplayOrder = 10 },
                new Category { Id = 11, Name = "Continuous Spell Card", DisplayOrder = 11 },
                new Category { Id = 12, Name = "Equip Spell Card", DisplayOrder = 12 },
                new Category { Id = 13, Name = "Quick-play Spell Card", DisplayOrder = 13 },
                new Category { Id = 14, Name = "Field Spell Card", DisplayOrder = 14 },
                new Category { Id = 15, Name = "Ritual Spell Card", DisplayOrder = 15 }
                );
        }
    }
}
