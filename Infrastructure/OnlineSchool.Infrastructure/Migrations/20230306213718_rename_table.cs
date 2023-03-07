using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSchool.Infrastructure.Migrations
{
    public partial class rename_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformationAdmission_Courses_CourseId",
                table: "InformationAdmission");

            migrationBuilder.DropForeignKey(
                name: "FK_InformationAdmission_Students_StudentId",
                table: "InformationAdmission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InformationAdmission",
                table: "InformationAdmission");

            migrationBuilder.RenameTable(
                name: "InformationAdmission",
                newName: "StudentCourseInformation");

            migrationBuilder.RenameIndex(
                name: "IX_InformationAdmission_StudentId",
                table: "StudentCourseInformation",
                newName: "IX_StudentCourseInformation_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_InformationAdmission_CourseId",
                table: "StudentCourseInformation",
                newName: "IX_StudentCourseInformation_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourseInformation",
                table: "StudentCourseInformation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseInformation_Courses_CourseId",
                table: "StudentCourseInformation",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseInformation_Students_StudentId",
                table: "StudentCourseInformation",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseInformation_Courses_CourseId",
                table: "StudentCourseInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseInformation_Students_StudentId",
                table: "StudentCourseInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourseInformation",
                table: "StudentCourseInformation");

            migrationBuilder.RenameTable(
                name: "StudentCourseInformation",
                newName: "InformationAdmission");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourseInformation_StudentId",
                table: "InformationAdmission",
                newName: "IX_InformationAdmission_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourseInformation_CourseId",
                table: "InformationAdmission",
                newName: "IX_InformationAdmission_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InformationAdmission",
                table: "InformationAdmission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InformationAdmission_Courses_CourseId",
                table: "InformationAdmission",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InformationAdmission_Students_StudentId",
                table: "InformationAdmission",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
