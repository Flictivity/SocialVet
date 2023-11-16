using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "appointment_status",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "creation_date",
                table: "appointments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "appointment_status",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "creation_date",
                table: "appointments");
        }
    }
}
