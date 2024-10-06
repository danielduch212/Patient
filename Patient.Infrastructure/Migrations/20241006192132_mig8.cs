using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientsDiseases_Diseases_DiseaseId",
                table: "PatientsDiseases");

            migrationBuilder.DropIndex(
                name: "IX_PatientsDiseases_DiseaseId",
                table: "PatientsDiseases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PatientsDiseases_DiseaseId",
                table: "PatientsDiseases",
                column: "DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsDiseases_Diseases_DiseaseId",
                table: "PatientsDiseases",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
