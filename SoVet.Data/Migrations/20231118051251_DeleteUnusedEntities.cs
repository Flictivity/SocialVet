using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUnusedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_facilities_value_added_taxes_value_added_tax_id",
                table: "facilities");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "value_added_taxes");

            migrationBuilder.DropIndex(
                name: "ix_facilities_value_added_tax_id",
                table: "facilities");

            migrationBuilder.DropColumn(
                name: "value_added_tax_id",
                table: "facilities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "value_added_tax_id",
                table: "facilities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    appointment_id = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    payment_type = table.Column<int>(type: "integer", nullable: false),
                    sum = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payments", x => x.id);
                    table.ForeignKey(
                        name: "fk_payments_appointments_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "appointments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "value_added_taxes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_value_added_taxes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_facilities_value_added_tax_id",
                table: "facilities",
                column: "value_added_tax_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_appointment_id",
                table: "payments",
                column: "appointment_id");

            migrationBuilder.AddForeignKey(
                name: "fk_facilities_value_added_taxes_value_added_tax_id",
                table: "facilities",
                column: "value_added_tax_id",
                principalTable: "value_added_taxes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
