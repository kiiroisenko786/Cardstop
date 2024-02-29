using Cardstop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cardstop.DataAccess.Data
{
    /*
     Any class here must implement/inherit DbContext, which is basically the root
    class of EntityFramework core, using which EntityFramework is accessible
     */
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
                
        }
        
        // Create DbSet for table of categories
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies{ get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        // Override OnModelCreating to seed category table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<Company>().HasData(
                new Company {
                    Id = 1, 
                    Name = "Funtech Industries", 
                    StreetAddress = "Funtech Street", 
                    City = "Funland", 
                    PostZipCode = "FUNL4ND", 
                    State = "", 
                    PhoneNumber = "01882736546"
                },
                new Company {
                    Id = 2, 
                    Name = "Mishima Financial Group", 
                    StreetAddress = "Mishima Building, Minato", 
                    City = "Tokyo", 
                    PostZipCode = "M15HIMA", 
                    State = "", 
                    PhoneNumber = "3124434666" }
                );

            modelBuilder.Entity<Product>().HasData(
               new Product 
               {
                   Id = 1,
                   Name = "Blue-Eyes White Dragon",
                   Description = "LC01-EN004 - PSA 10 GEM MT - Ultra Rare Limited Edition 7118",
                   ListPrice = 94.99,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 2,
                   Name = "Red Dragon Archfiend/Assault Mode",
                   Description = "1st Ed CRMS-EN004 PSA Near Mint-Mint 8",
                   ListPrice = 411.72,
                   ImageUrl = "",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 3,
                   Name = "Time Wizard of Tomorrow",
                   Description = "Secret Rare - DLCS-EN147 - PSA 8",
                   ListPrice = 57.56,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 4,
                   Name = "Stardust Dragon",
                   Description = "TDGS-EN040 Unlimited Ghost Rare Near Mint",
                   ListPrice = 411.72,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 5,
                   Name = "Black Luster Soldier",
                   Description = "DPBC-EN006 \r\nSuper Rare \r\n1st Edition   \r\nDuelist Pack: Battle City 2015\r\nCondition: MINT",
                   ListPrice = 48.00,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 6,
                   Name = "Number 99: Utopic Dragon",
                   Description = "Secret • MP15 EN190",
                   ListPrice = 48.00,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 7,
                   Name = "Borrelend Dragon",
                   Description = "GFP2-EN006 Ultra Rare 1st Edition",
                   ListPrice = 1.50,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 8,
                   Name = "Magic Cylinder",
                   Description = "YS12-EN034 - Common 1st Edition Singles",
                   ListPrice = 0.59,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 9,
                   Name = "Solemn Judgement",
                   Description = "MAGO-EN051 - Premium Gold Rare 1st Edition",
                   ListPrice = 4.99,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 10,
                   Name = "Monster Reborn",
                   Description = "LEHD-ENC16 - Common 1st Edition",
                   ListPrice = 0.49,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 11,
                   Name = "Dimensional Fissure",
                   Description = "BLMR-EN088 - Ultra Rare 1st Edition",
                   ListPrice = 0.99,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 12,
                   Name = "United We Stand",
                   Description = "SBC1-ENB16 - Common 1st Edition",
                   ListPrice = 0.25,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 13,
                   Name = "Book of Moon",
                   Description = " SDMA-EN023 - Common Unlimited",
                   ListPrice = 0.79,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 14,
                   Name = "Mystic Mine",
                   Description = "Maximum Gold: El Dorado MGED-EN047 1st Edition Premium",
                   ListPrice = 4.00,
                   ImageUrl="",
                   CategoryId = 1
               },
               new Product
               {
                   Id = 15,
                   Name = "Black Luster Ritual",
                   Description = "DPYG-EN022 - Common Unlimited",
                   ListPrice = 0.35,
                   ImageUrl="",
                   CategoryId = 1
               }
               );
        }
    }
}
