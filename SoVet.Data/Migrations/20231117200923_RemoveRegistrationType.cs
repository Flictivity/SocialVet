using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRegistrationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_registrations_registration_types_registration_type_id",
                table: "registrations");

            migrationBuilder.DropTable(
                name: "registration_types");

            migrationBuilder.DropIndex(
                name: "ix_registrations_registration_type_id",
                table: "registrations");

            migrationBuilder.DropColumn(
                name: "registration_type_id",
                table: "registrations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "registration_type_id",
                table: "registrations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "registration_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_registration_types", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_registrations_registration_type_id",
                table: "registrations",
                column: "registration_type_id");

            migrationBuilder.AddForeignKey(
                name: "fk_registrations_registration_types_registration_type_id",
                table: "registrations",
                column: "registration_type_id",
                principalTable: "registration_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
