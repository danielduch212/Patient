using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newReportsBetterReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HealthRating",
                table: "Reports",
                newName: "PatientsHealthRating");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Reports",
                newName: "PatientsSymptoms");

            migrationBuilder.RenameColumn(
                name: "AnswersForQuestions",
                table: "Reports",
                newName: "PatientsAnswersForQuestions");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalDescription",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalDescription",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "PatientsSymptoms",
                table: "Reports",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "PatientsHealthRating",
                table: "Reports",
                newName: "HealthRating");

            migrationBuilder.RenameColumn(
                name: "PatientsAnswersForQuestions",
                table: "Reports",
                newName: "AnswersForQuestions");
        }
    }
}
