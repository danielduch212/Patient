using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTratedDiseases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientsDiseases_Patients_PatientId",
                table: "PatientsDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientsDiseases_Patients_PatientId1",
                table: "PatientsDiseases");

            migrationBuilder.DropIndex(
                name: "IX_PatientsDiseases_PatientId1",
                table: "PatientsDiseases");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "PatientsDiseases");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "PatientsDiseases",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentlyTrated",
                table: "PatientsDiseases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsDiseases_Patients_PatientId",
                table: "PatientsDiseases",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientsDiseases_Patients_PatientId",
                table: "PatientsDiseases");

            migrationBuilder.DropColumn(
                name: "IsCurrentlyTrated",
                table: "PatientsDiseases");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "PatientsDiseases",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "PatientsDiseases",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientsDiseases_PatientId1",
                table: "PatientsDiseases",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsDiseases_Patients_PatientId",
                table: "PatientsDiseases",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsDiseases_Patients_PatientId1",
                table: "PatientsDiseases",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
