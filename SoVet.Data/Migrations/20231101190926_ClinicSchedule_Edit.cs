using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClinicSchedule_Edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "day_of_week",
                table: "clinic_schedules");

            migrationBuilder.AddColumn<bool>(
                name: "is_actual",
                table: "clinic_schedules",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_actual",
                table: "clinic_schedules");

            migrationBuilder.AddColumn<int>(
                name: "day_of_week",
                table: "clinic_schedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
