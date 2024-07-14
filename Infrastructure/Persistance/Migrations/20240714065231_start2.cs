using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class start2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FooterAddres");

            migrationBuilder.CreateTable(
                name: "FooterAddresses",
                columns: table => new
                {
                    FooterAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FooterAddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterAddressContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterAddressPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterAddressMail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterAddresses", x => x.FooterAddressId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FooterAddresses");

            migrationBuilder.CreateTable(
                name: "FooterAddres",
                columns: table => new
                {
                    FooterAddresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FooterAddresContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterAddresDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterAddresMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterAddresPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterAddres", x => x.FooterAddresId);
                });
        }
    }
}
