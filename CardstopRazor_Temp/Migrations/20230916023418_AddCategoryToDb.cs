using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CardstopRazor_Temp.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Normal Monster" },
                    { 2, 2, "Effect Monster" },
                    { 3, 3, "Fusion Monster" },
                    { 4, 4, "Synchro Monster" },
                    { 5, 5, "Ritual Monster" },
                    { 6, 6, "XYZ Monster" },
                    { 7, 7, "Link Monster" },
                    { 8, 8, "Normal Trap Card" },
                    { 9, 9, "Counter Trap Card" },
                    { 10, 10, "Normal Spell Card" },
                    { 11, 11, "Continuous Spell Card" },
                    { 12, 12, "Equip Spell Card" },
                    { 13, 13, "Quick-play Spell Card" },
                    { 14, 14, "Field Spell Card" },
                    { 15, 15, "Ritual Spell Card" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
