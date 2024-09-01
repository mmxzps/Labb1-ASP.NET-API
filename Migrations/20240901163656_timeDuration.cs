using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb1_ASP.NET_API.Migrations
{
    /// <inheritdoc />
    public partial class timeDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "Bookings",
                newName: "BookingTimeEnd");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingTime",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "BookingTimeEnd",
                table: "Bookings",
                newName: "BookingDate");
        }
    }
}
