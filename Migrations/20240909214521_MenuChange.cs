using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb1_ASP.NET_API.Migrations
{
    /// <inheritdoc />
    public partial class MenuChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPopular",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IsPopular",
                table: "Menu");
        }
    }
}
