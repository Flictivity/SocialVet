using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SoVet.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRecommendationRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_appointments_recommendations_recommendation_id",
                table: "appointments");

            migrationBuilder.DropTable(
                name: "recommendations");

            migrationBuilder.DropIndex(
                name: "ix_appointments_recommendation_id",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "recommendation_id",
                table: "appointments");

            migrationBuilder.AddColumn<string>(
                name: "recommendations",
                table: "appointments",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "recommendations",
                table: "appointments");

            migrationBuilder.AddColumn<int>(
                name: "recommendation_id",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "recommendations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    recommendations_for_care = table.Column<string>(type: "text", nullable: true),
                    treatment_plan = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recommendations", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_appointments_recommendation_id",
                table: "appointments",
                column: "recommendation_id");

            migrationBuilder.AddForeignKey(
                name: "fk_appointments_recommendations_recommendation_id",
                table: "appointments",
                column: "recommendation_id",
                principalTable: "recommendations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
