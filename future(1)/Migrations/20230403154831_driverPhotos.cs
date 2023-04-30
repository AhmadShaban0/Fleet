using Microsoft.EntityFrameworkCore.Migrations;

namespace future_1_.Migrations
{
    public partial class driverPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiseaseFreeCert_PH",
                table: "drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriverLicense_PH",
                table: "drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDPhoto",
                table: "drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NonConvictionCert_PH",
                table: "drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalPhoto",
                table: "drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityPermit_PH",
                table: "drivers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiseaseFreeCert_PH",
                table: "drivers");

            migrationBuilder.DropColumn(
                name: "DriverLicense_PH",
                table: "drivers");

            migrationBuilder.DropColumn(
                name: "IDPhoto",
                table: "drivers");

            migrationBuilder.DropColumn(
                name: "NonConvictionCert_PH",
                table: "drivers");

            migrationBuilder.DropColumn(
                name: "PersonalPhoto",
                table: "drivers");

            migrationBuilder.DropColumn(
                name: "SecurityPermit_PH",
                table: "drivers");
        }
    }
}
