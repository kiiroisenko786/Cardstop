﻿// <auto-generated />
using System;
using Cardstop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cardstop.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240227122713_addCompanyToUser")]
    partial class addCompanyToUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cardstop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Normal Monster"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Effect Monster"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Fusion Monster"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Synchro Monster"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 5,
                            Name = "Ritual Monster"
                        },
                        new
                        {
                            Id = 6,
                            DisplayOrder = 6,
                            Name = "XYZ Monster"
                        },
                        new
                        {
                            Id = 7,
                            DisplayOrder = 7,
                            Name = "Link Monster"
                        },
                        new
                        {
                            Id = 8,
                            DisplayOrder = 8,
                            Name = "Normal Trap Card"
                        },
                        new
                        {
                            Id = 9,
                            DisplayOrder = 9,
                            Name = "Counter Trap Card"
                        },
                        new
                        {
                            Id = 10,
                            DisplayOrder = 10,
                            Name = "Normal Spell Card"
                        },
                        new
                        {
                            Id = 11,
                            DisplayOrder = 11,
                            Name = "Continuous Spell Card"
                        },
                        new
                        {
                            Id = 12,
                            DisplayOrder = 12,
                            Name = "Equip Spell Card"
                        },
                        new
                        {
                            Id = 13,
                            DisplayOrder = 13,
                            Name = "Quick-play Spell Card"
                        },
                        new
                        {
                            Id = 14,
                            DisplayOrder = 14,
                            Name = "Field Spell Card"
                        },
                        new
                        {
                            Id = 15,
                            DisplayOrder = 15,
                            Name = "Ritual Spell Card"
                        });
                });

            modelBuilder.Entity("Cardstop.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Funland",
                            Name = "Funtech Industries",
                            PhoneNumber = "01882736546",
                            PostZipCode = "FUNL4ND",
                            State = "",
                            StreetAddress = "Funtech Street"
                        },
                        new
                        {
                            Id = 2,
                            City = "Tokyo",
                            Name = "Mishima Financial Group",
                            PhoneNumber = "3124434666",
                            PostZipCode = "M15HIMA",
                            State = "",
                            StreetAddress = "Mishima Building, Minato"
                        });
                });

            modelBuilder.Entity("Cardstop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "LC01-EN004 - PSA 10 GEM MT - Ultra Rare Limited Edition 7118",
                            ImageUrl = "",
                            ListPrice = 94.989999999999995,
                            Name = "Blue-Eyes White Dragon",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "1st Ed CRMS-EN004 PSA Near Mint-Mint 8",
                            ImageUrl = "",
                            ListPrice = 411.72000000000003,
                            Name = "Red Dragon Archfiend/Assault Mode",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Secret Rare - DLCS-EN147 - PSA 8",
                            ImageUrl = "",
                            ListPrice = 57.560000000000002,
                            Name = "Time Wizard of Tomorrow",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "TDGS-EN040 Unlimited Ghost Rare Near Mint",
                            ImageUrl = "",
                            ListPrice = 411.72000000000003,
                            Name = "Stardust Dragon",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "DPBC-EN006 \r\nSuper Rare \r\n1st Edition   \r\nDuelist Pack: Battle City 2015\r\nCondition: MINT",
                            ImageUrl = "",
                            ListPrice = 48.0,
                            Name = "Black Luster Soldier",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Description = "Secret • MP15 EN190",
                            ImageUrl = "",
                            ListPrice = 48.0,
                            Name = "Number 99: Utopic Dragon",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Description = "GFP2-EN006 Ultra Rare 1st Edition",
                            ImageUrl = "",
                            ListPrice = 1.5,
                            Name = "Borrelend Dragon",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            Description = "YS12-EN034 - Common 1st Edition Singles",
                            ImageUrl = "",
                            ListPrice = 0.58999999999999997,
                            Name = "Magic Cylinder",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Description = "MAGO-EN051 - Premium Gold Rare 1st Edition",
                            ImageUrl = "",
                            ListPrice = 4.9900000000000002,
                            Name = "Solemn Judgement",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            Description = "LEHD-ENC16 - Common 1st Edition",
                            ImageUrl = "",
                            ListPrice = 0.48999999999999999,
                            Name = "Monster Reborn",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 1,
                            Description = "BLMR-EN088 - Ultra Rare 1st Edition",
                            ImageUrl = "",
                            ListPrice = 0.98999999999999999,
                            Name = "Dimensional Fissure",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 1,
                            Description = "SBC1-ENB16 - Common 1st Edition",
                            ImageUrl = "",
                            ListPrice = 0.25,
                            Name = "United We Stand",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 1,
                            Description = " SDMA-EN023 - Common Unlimited",
                            ImageUrl = "",
                            ListPrice = 0.79000000000000004,
                            Name = "Book of Moon",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 1,
                            Description = "Maximum Gold: El Dorado MGED-EN047 1st Edition Premium",
                            ImageUrl = "",
                            ListPrice = 4.0,
                            Name = "Mystic Mine",
                            ProductStock = 0
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 1,
                            Description = "DPYG-EN022 - Common Unlimited",
                            ImageUrl = "",
                            ListPrice = 0.34999999999999998,
                            Name = "Black Luster Ritual",
                            ProductStock = 0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Cardstop.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("CompanyId");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Cardstop.Models.Product", b =>
                {
                    b.HasOne("Cardstop.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cardstop.Models.ApplicationUser", b =>
                {
                    b.HasOne("Cardstop.Models.Company", "company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.Navigation("company");
                });
#pragma warning restore 612, 618
        }
    }
}
