using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class addIsDeletedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "facilities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "facilities");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "clients");
        }
    }
}
