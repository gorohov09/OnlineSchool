using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSchool.Infrastructure.Migrations
{
    public partial class addTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTaskInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSolve = table.Column<bool>(type: "bit", nullable: false),
                    CountAttempts = table.Column<int>(type: "int", nullable: false),
                    TimeLastAttempt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTaskInformation_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTaskInformation_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskInformation_StudentId",
                table: "UserTaskInformation",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskInformation_TaskId",
                table: "UserTaskInformation",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTaskInformation");
        }
    }
}
