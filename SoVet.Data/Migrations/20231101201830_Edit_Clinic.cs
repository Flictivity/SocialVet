using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Clinic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_actual",
                table: "clinic_schedules");

            migrationBuilder.AddColumn<string>(
                name: "clinic_name",
                table: "clinic_schedules",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clinic_name",
                table: "clinic_schedules");

            migrationBuilder.AddColumn<bool>(
                name: "is_actual",
                table: "clinic_schedules",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
