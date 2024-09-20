using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationReportDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Reports_ReportId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ReportId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Doctors");

            migrationBuilder.CreateTable(
                name: "DoctorReport",
                columns: table => new
                {
                    DoctorsToCheckId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportsToCheckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorReport", x => new { x.DoctorsToCheckId, x.ReportsToCheckId });
                    table.ForeignKey(
                        name: "FK_DoctorReport_Doctors_DoctorsToCheckId",
                        column: x => x.DoctorsToCheckId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorReport_Reports_ReportsToCheckId",
                        column: x => x.ReportsToCheckId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorReport1",
                columns: table => new
                {
                    DoctorsWhoCheckedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportsCheckedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorReport1", x => new { x.DoctorsWhoCheckedId, x.ReportsCheckedId });
                    table.ForeignKey(
                        name: "FK_DoctorReport1_Doctors_DoctorsWhoCheckedId",
                        column: x => x.DoctorsWhoCheckedId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorReport1_Reports_ReportsCheckedId",
                        column: x => x.ReportsCheckedId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReport_ReportsToCheckId",
                table: "DoctorReport",
                column: "ReportsToCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReport1_ReportsCheckedId",
                table: "DoctorReport1",
                column: "ReportsCheckedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorReport");

            migrationBuilder.DropTable(
                name: "DoctorReport1");

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ReportId",
                table: "Doctors",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Reports_ReportId",
                table: "Doctors",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");
        }
    }
}
