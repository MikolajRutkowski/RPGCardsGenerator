using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGCardsGenerator.Migrations
{
    /// <inheritdoc />
    public partial class update02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "reputacja",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Neutralny");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "reputacja",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Neutralny",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
