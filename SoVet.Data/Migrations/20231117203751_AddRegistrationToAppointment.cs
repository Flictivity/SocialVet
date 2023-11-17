using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistrationToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "registration_id",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_appointments_registration_id",
                table: "appointments",
                column: "registration_id");

            migrationBuilder.AddForeignKey(
                name: "fk_appointments_registrations_registration_id",
                table: "appointments",
                column: "registration_id",
                principalTable: "registrations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_appointments_registrations_registration_id",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "ix_appointments_registration_id",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "registration_id",
                table: "appointments");
        }
    }
}
