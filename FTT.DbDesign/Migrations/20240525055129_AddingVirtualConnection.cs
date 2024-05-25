using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTT.DbDesign.Migrations
{
    /// <inheritdoc />
    public partial class AddingVirtualConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkingExerciseSets_WorkingExerciseId",
                table: "WorkingExerciseSets",
                column: "WorkingExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingExerciseSets_WorkingExercises_WorkingExerciseId",
                table: "WorkingExerciseSets",
                column: "WorkingExerciseId",
                principalTable: "WorkingExercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExerciseSets_WorkingExercises_WorkingExerciseId",
                table: "WorkingExerciseSets");

            migrationBuilder.DropIndex(
                name: "IX_WorkingExerciseSets_WorkingExerciseId",
                table: "WorkingExerciseSets");
        }
    }
}
