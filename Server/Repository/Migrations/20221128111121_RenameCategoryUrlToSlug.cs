using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hollox.BlazorEcommerce.Server.Migrations
{
    public partial class RenameCategoryUrlToSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Categories",
                newName: "Slug");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Categories",
                newName: "Url");
        }
    }
}
