using Microsoft.EntityFrameworkCore.Migrations;

namespace Snowshop.Migrations
{
    public partial class AddSnowboardcompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "company",
                table: "Snowboards",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "company",
                table: "Snowboards");
        }
    }
}
