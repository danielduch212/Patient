using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPropertyRecommandationPRescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MedicineName",
                table: "Prescriptions",
                newName: "MedicineNames");

            migrationBuilder.AlterColumn<decimal>(
                name: "DoseOfMedicine",
                table: "Prescriptions",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<bool>(
                name: "AskForVisitOnline",
                table: "MedicalRecommandations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AskForVisitOnline",
                table: "MedicalRecommandations");

            migrationBuilder.RenameColumn(
                name: "MedicineNames",
                table: "Prescriptions",
                newName: "MedicineName");

            migrationBuilder.AlterColumn<decimal>(
                name: "DoseOfMedicine",
                table: "Prescriptions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
