using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLife.Migrations
{
    /// <inheritdoc />
    public partial class AddMoodEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Money",
                table: "SmartLives",
                newName: "Monthly_salary");

            migrationBuilder.AlterColumn<int>(
                name: "Personality",
                table: "SmartLives",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Mood",
                table: "SmartLives",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Monthly_salary",
                table: "SmartLives",
                newName: "Money");

            migrationBuilder.AlterColumn<string>(
                name: "Personality",
                table: "SmartLives",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Mood",
                table: "SmartLives",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
