using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGCardsGenerator.Migrations
{
    /// <inheritdoc />
    public partial class _02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Character_CharacterId",
                table: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_CharacterId",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Statistics");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Statistics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Opis",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_CharaterId",
                table: "Statistics",
                column: "CharaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Character_CharaterId",
                table: "Statistics",
                column: "CharaterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Character_CharaterId",
                table: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_CharaterId",
                table: "Statistics");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Statistics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Opis");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_CharacterId",
                table: "Statistics",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Character_CharacterId",
                table: "Statistics",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
