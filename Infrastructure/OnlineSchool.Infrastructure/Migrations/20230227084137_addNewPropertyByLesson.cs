using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSchool.Infrastructure.Migrations
{
    public partial class addNewPropertyByLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoEmbedCode",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoEmbedCode",
                table: "Lessons");
        }
    }
}
