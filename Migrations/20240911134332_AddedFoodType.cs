using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb1_ASP.NET_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedFoodType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodTypee",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodTypee",
                table: "Menu");
        }
    }
}
