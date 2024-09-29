using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_MedicalRecommandations_MedicalRecommandationId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_MedicalRecommandationId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "MedicalRecommandationId",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "MedicalRecommandations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecommandations_ReportId",
                table: "MedicalRecommandations",
                column: "ReportId",
                unique: true,
                filter: "[ReportId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecommandations_Reports_ReportId",
                table: "MedicalRecommandations",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecommandations_Reports_ReportId",
                table: "MedicalRecommandations");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecommandations_ReportId",
                table: "MedicalRecommandations");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "MedicalRecommandations");

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecommandationId",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_MedicalRecommandationId",
                table: "Reports",
                column: "MedicalRecommandationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_MedicalRecommandations_MedicalRecommandationId",
                table: "Reports",
                column: "MedicalRecommandationId",
                principalTable: "MedicalRecommandations",
                principalColumn: "Id");
        }
    }
}
