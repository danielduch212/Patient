using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReportChanged2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnswearsForQuestions",
                table: "Reports",
                newName: "AnswersForQuestions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnswersForQuestions",
                table: "Reports",
                newName: "AnswearsForQuestions");
        }
    }
}
