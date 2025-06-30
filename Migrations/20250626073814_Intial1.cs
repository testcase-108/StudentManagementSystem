using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication7.Migrations
{
    /// <inheritdoc />
    public partial class Intial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StuCousrse_courses_CourseId",
                table: "StuCousrse");

            migrationBuilder.DropForeignKey(
                name: "FK_StuCousrse_students_StudentId",
                table: "StuCousrse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StuCousrse",
                table: "StuCousrse");

            migrationBuilder.RenameTable(
                name: "StuCousrse",
                newName: "StuCourse");

            migrationBuilder.RenameIndex(
                name: "IX_StuCousrse_CourseId",
                table: "StuCourse",
                newName: "IX_StuCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StuCourse",
                table: "StuCourse",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StuCourse_courses_CourseId",
                table: "StuCourse",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StuCourse_students_StudentId",
                table: "StuCourse",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StuCourse_courses_CourseId",
                table: "StuCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StuCourse_students_StudentId",
                table: "StuCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StuCourse",
                table: "StuCourse");

            migrationBuilder.RenameTable(
                name: "StuCourse",
                newName: "StuCousrse");

            migrationBuilder.RenameIndex(
                name: "IX_StuCourse_CourseId",
                table: "StuCousrse",
                newName: "IX_StuCousrse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StuCousrse",
                table: "StuCousrse",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StuCousrse_courses_CourseId",
                table: "StuCousrse",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StuCousrse_students_StudentId",
                table: "StuCousrse",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
