using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class migration_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogDescription",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogSubTitle",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogDescription",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogSubTitle",
                table: "Blogs");
        }
    }
}
