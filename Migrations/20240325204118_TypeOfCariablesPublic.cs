using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGCardsGenerator.Migrations
{
    /// <inheritdoc />
    public partial class TypeOfCariablesPublic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Statistics");
        }
    }
}
