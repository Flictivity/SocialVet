using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClinicScheduleUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "appointment_duration",
                table: "clinic_schedules",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "pause_duration",
                table: "clinic_schedules",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "appointment_duration",
                table: "clinic_schedules");

            migrationBuilder.DropColumn(
                name: "pause_duration",
                table: "clinic_schedules");
        }
    }
}
