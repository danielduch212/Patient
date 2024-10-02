using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class diseases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OnlyPreventionPatient",
                table: "Patients",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Diseases",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "Diseases",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_PatientId",
                table: "Diseases",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_PatientId1",
                table: "Diseases",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_Patients_PatientId",
                table: "Diseases",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_Patients_PatientId1",
                table: "Diseases",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_Patients_PatientId",
                table: "Diseases");

            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_Patients_PatientId1",
                table: "Diseases");

            migrationBuilder.DropIndex(
                name: "IX_Diseases_PatientId",
                table: "Diseases");

            migrationBuilder.DropIndex(
                name: "IX_Diseases_PatientId1",
                table: "Diseases");

            migrationBuilder.DropColumn(
                name: "OnlyPreventionPatient",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Diseases");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Diseases");
        }
    }
}
