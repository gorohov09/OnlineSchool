using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSchool.Infrastructure.Migrations
{
    public partial class AddTime_InformationAdmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTaskInformation_Students_StudentId",
                table: "UserTaskInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTaskInformation_Tasks_TaskId",
                table: "UserTaskInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTaskInformation",
                table: "UserTaskInformation");

            migrationBuilder.RenameTable(
                name: "UserTaskInformation",
                newName: "StudentTaskInformation");

            migrationBuilder.RenameIndex(
                name: "IX_UserTaskInformation_TaskId",
                table: "StudentTaskInformation",
                newName: "IX_StudentTaskInformation_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTaskInformation_StudentId",
                table: "StudentTaskInformation",
                newName: "IX_StudentTaskInformation_StudentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdmission",
                table: "InformationAdmission",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTaskInformation",
                table: "StudentTaskInformation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTaskInformation_Students_StudentId",
                table: "StudentTaskInformation",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTaskInformation_Tasks_TaskId",
                table: "StudentTaskInformation",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTaskInformation_Students_StudentId",
                table: "StudentTaskInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTaskInformation_Tasks_TaskId",
                table: "StudentTaskInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTaskInformation",
                table: "StudentTaskInformation");

            migrationBuilder.DropColumn(
                name: "DateAdmission",
                table: "InformationAdmission");

            migrationBuilder.RenameTable(
                name: "StudentTaskInformation",
                newName: "UserTaskInformation");

            migrationBuilder.RenameIndex(
                name: "IX_StudentTaskInformation_TaskId",
                table: "UserTaskInformation",
                newName: "IX_UserTaskInformation_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentTaskInformation_StudentId",
                table: "UserTaskInformation",
                newName: "IX_UserTaskInformation_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTaskInformation",
                table: "UserTaskInformation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTaskInformation_Students_StudentId",
                table: "UserTaskInformation",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTaskInformation_Tasks_TaskId",
                table: "UserTaskInformation",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
