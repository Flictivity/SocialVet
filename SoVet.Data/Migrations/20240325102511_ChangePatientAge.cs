using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangePatientAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "patients");

            migrationBuilder.AddColumn<DateOnly>(
                name: "birth_date",
                table: "patients",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birth_date",
                table: "patients");

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "patients",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
