using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_MedicalRecommandations_medicalRecommandationId",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "medicalRecommandationId",
                table: "Reports",
                newName: "MedicalRecommandationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_medicalRecommandationId",
                table: "Reports",
                newName: "IX_Reports_MedicalRecommandationId");

            migrationBuilder.AddColumn<bool>(
                name: "AskForVisit",
                table: "MedicalRecommandations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_MedicalRecommandations_MedicalRecommandationId",
                table: "Reports",
                column: "MedicalRecommandationId",
                principalTable: "MedicalRecommandations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_MedicalRecommandations_MedicalRecommandationId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "AskForVisit",
                table: "MedicalRecommandations");

            migrationBuilder.RenameColumn(
                name: "MedicalRecommandationId",
                table: "Reports",
                newName: "medicalRecommandationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_MedicalRecommandationId",
                table: "Reports",
                newName: "IX_Reports_medicalRecommandationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_MedicalRecommandations_medicalRecommandationId",
                table: "Reports",
                column: "medicalRecommandationId",
                principalTable: "MedicalRecommandations",
                principalColumn: "Id");
        }
    }
}
