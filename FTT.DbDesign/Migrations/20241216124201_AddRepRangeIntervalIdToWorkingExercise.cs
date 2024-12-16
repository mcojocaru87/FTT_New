using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTT.DbDesign.Migrations
{
    /// <inheritdoc />
    public partial class AddRepRangeIntervalIdToWorkingExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepRangeIntervalId",
                table: "WorkingExercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepRangeIntervalId",
                table: "WorkingExercises");
        }
    }
}
