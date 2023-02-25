using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSchool.Infrastructure.Migrations
{
    public partial class RemoveCountTask_In_Course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountTasks",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountTasks",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
