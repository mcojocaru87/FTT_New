using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTT.DbDesign.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseIdToRepRangeIntervalsTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "RepRangeIntervals",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "RepRangeIntervals");
        }
    }
}
