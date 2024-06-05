using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTT.DbDesign.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSettingsTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Settings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinReps",
                table: "Settings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "MinReps",
                table: "Settings");
        }
    }
}
