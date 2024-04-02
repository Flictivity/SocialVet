using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedFieldToFacilityCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "clients");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "facility_categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "facility_categories");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
