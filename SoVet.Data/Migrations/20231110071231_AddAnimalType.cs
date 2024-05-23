using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAnimalType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "animal_type",
                table: "patients",
                newName: "animal_type_id");

            migrationBuilder.CreateTable(
                name: "animal_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_animal_type", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_patients_animal_type_id",
                table: "patients",
                column: "animal_type_id");

            migrationBuilder.AddForeignKey(
                name: "fk_patients_animal_type_animal_type_id",
                table: "patients",
                column: "animal_type_id",
                principalTable: "animal_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_patients_animal_type_animal_type_id",
                table: "patients");

            migrationBuilder.DropTable(
                name: "animal_type");

            migrationBuilder.DropIndex(
                name: "ix_patients_animal_type_id",
                table: "patients");

            migrationBuilder.RenameColumn(
                name: "animal_type_id",
                table: "patients",
                newName: "animal_type");
        }
    }
}
