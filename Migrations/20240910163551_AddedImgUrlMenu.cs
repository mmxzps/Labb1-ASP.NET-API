using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb1_ASP.NET_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedImgUrlMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Menu");
        }
    }
}
