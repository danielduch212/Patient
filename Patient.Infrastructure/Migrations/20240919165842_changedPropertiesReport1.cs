using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedPropertiesReport1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "medicalRecommandationId",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_medicalRecommandationId",
                table: "Reports",
                column: "medicalRecommandationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_MedicalRecommandations_medicalRecommandationId",
                table: "Reports",
                column: "medicalRecommandationId",
                principalTable: "MedicalRecommandations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_MedicalRecommandations_medicalRecommandationId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_medicalRecommandationId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "medicalRecommandationId",
                table: "Reports");
        }
    }
}
