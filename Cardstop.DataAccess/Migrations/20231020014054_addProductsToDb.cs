using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cardstop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ListPrice", "Name" },
                values: new object[,]
                {
                    { 1, "LC01-EN004 - PSA 10 GEM MT - Ultra Rare Limited Edition 7118", 94.989999999999995, "Blue-Eyes White Dragon" },
                    { 2, "1st Ed CRMS-EN004 PSA Near Mint-Mint 8", 411.72000000000003, "Red Dragon Archfiend/Assault Mode" },
                    { 3, "Secret Rare - DLCS-EN147 - PSA 8", 57.560000000000002, "Time Wizard of Tomorrow" },
                    { 4, "TDGS-EN040 Unlimited Ghost Rare Near Mint", 411.72000000000003, "Stardust Dragon" },
                    { 5, "DPBC-EN006 \r\nSuper Rare \r\n1st Edition   \r\nDuelist Pack: Battle City 2015\r\nCondition: MINT", 48.0, "Black Luster Soldier" },
                    { 6, "Secret • MP15 EN190", 48.0, "Number 99: Utopic Dragon" },
                    { 7, "GFP2-EN006 Ultra Rare 1st Edition", 1.5, "Borrelend Dragon" },
                    { 8, "YS12-EN034 - Common 1st Edition Singles", 0.58999999999999997, "Magic Cylinder" },
                    { 9, "MAGO-EN051 - Premium Gold Rare 1st Edition", 4.9900000000000002, "Solemn Judgement" },
                    { 10, "LEHD-ENC16 - Common 1st Edition", 0.48999999999999999, "Monster Reborn" },
                    { 11, "BLMR-EN088 - Ultra Rare 1st Edition", 0.98999999999999999, "Dimensional Fissure" },
                    { 12, "SBC1-ENB16 - Common 1st Edition", 0.25, "United We Stand" },
                    { 13, " SDMA-EN023 - Common Unlimited", 0.79000000000000004, "Book of Moon" },
                    { 14, "Maximum Gold: El Dorado MGED-EN047 1st Edition Premium", 4.0, "Mystic Mine" },
                    { 15, "DPYG-EN022 - Common Unlimited", 0.34999999999999998, "Black Luster Ritual" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
