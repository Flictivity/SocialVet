using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentDiagnosisRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointment_diagnoses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    result = table.Column<int>(type: "integer", nullable: false),
                    edit_date = table.Column<DateOnly>(type: "date", nullable: false),
                    appointment_id = table.Column<int>(type: "integer", nullable: false),
                    diagnosis_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appointment_diagnoses", x => x.id);
                    table.ForeignKey(
                        name: "fk_appointment_diagnoses_appointments_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "appointments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointment_diagnoses_diagnoses_diagnosis_id",
                        column: x => x.diagnosis_id,
                        principalTable: "diagnoses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_appointment_diagnoses_appointment_id",
                table: "appointment_diagnoses",
                column: "appointment_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_diagnoses_diagnosis_id",
                table: "appointment_diagnoses",
                column: "diagnosis_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment_diagnoses");

            migrationBuilder.AddColumn<int>(
                name: "appointment_id",
                table: "diagnoses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "date",
                table: "diagnoses",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "result",
                table: "diagnoses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_diagnoses_appointment_id",
                table: "diagnoses",
                column: "appointment_id");

            migrationBuilder.AddForeignKey(
                name: "fk_diagnoses_appointments_appointment_id",
                table: "diagnoses",
                column: "appointment_id",
                principalTable: "appointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
