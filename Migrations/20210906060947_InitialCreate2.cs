using Microsoft.EntityFrameworkCore.Migrations;

namespace Snowshop.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stock",
                table: "Snowboards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "stock",
                table: "Snowboards",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
