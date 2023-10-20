﻿// <auto-generated />
using Cardstop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cardstop.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-rc.1.23419.6")
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

            modelBuilder.Entity("Cardstop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "LC01-EN004 - PSA 10 GEM MT - Ultra Rare Limited Edition 7118",
                            ListPrice = 94.989999999999995,
                            Name = "Blue-Eyes White Dragon"
                        },
                        new
                        {
                            Id = 2,
                            Description = "1st Ed CRMS-EN004 PSA Near Mint-Mint 8",
                            ListPrice = 411.72000000000003,
                            Name = "Red Dragon Archfiend/Assault Mode"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Secret Rare - DLCS-EN147 - PSA 8",
                            ListPrice = 57.560000000000002,
                            Name = "Time Wizard of Tomorrow"
                        },
                        new
                        {
                            Id = 4,
                            Description = "TDGS-EN040 Unlimited Ghost Rare Near Mint",
                            ListPrice = 411.72000000000003,
                            Name = "Stardust Dragon"
                        },
                        new
                        {
                            Id = 5,
                            Description = "DPBC-EN006 \r\nSuper Rare \r\n1st Edition   \r\nDuelist Pack: Battle City 2015\r\nCondition: MINT",
                            ListPrice = 48.0,
                            Name = "Black Luster Soldier"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Secret • MP15 EN190",
                            ListPrice = 48.0,
                            Name = "Number 99: Utopic Dragon"
                        },
                        new
                        {
                            Id = 7,
                            Description = "GFP2-EN006 Ultra Rare 1st Edition",
                            ListPrice = 1.5,
                            Name = "Borrelend Dragon"
                        },
                        new
                        {
                            Id = 8,
                            Description = "YS12-EN034 - Common 1st Edition Singles",
                            ListPrice = 0.58999999999999997,
                            Name = "Magic Cylinder"
                        },
                        new
                        {
                            Id = 9,
                            Description = "MAGO-EN051 - Premium Gold Rare 1st Edition",
                            ListPrice = 4.9900000000000002,
                            Name = "Solemn Judgement"
                        },
                        new
                        {
                            Id = 10,
                            Description = "LEHD-ENC16 - Common 1st Edition",
                            ListPrice = 0.48999999999999999,
                            Name = "Monster Reborn"
                        },
                        new
                        {
                            Id = 11,
                            Description = "BLMR-EN088 - Ultra Rare 1st Edition",
                            ListPrice = 0.98999999999999999,
                            Name = "Dimensional Fissure"
                        },
                        new
                        {
                            Id = 12,
                            Description = "SBC1-ENB16 - Common 1st Edition",
                            ListPrice = 0.25,
                            Name = "United We Stand"
                        },
                        new
                        {
                            Id = 13,
                            Description = " SDMA-EN023 - Common Unlimited",
                            ListPrice = 0.79000000000000004,
                            Name = "Book of Moon"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Maximum Gold: El Dorado MGED-EN047 1st Edition Premium",
                            ListPrice = 4.0,
                            Name = "Mystic Mine"
                        },
                        new
                        {
                            Id = 15,
                            Description = "DPYG-EN022 - Common Unlimited",
                            ListPrice = 0.34999999999999998,
                            Name = "Black Luster Ritual"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
