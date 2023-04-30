using Microsoft.EntityFrameworkCore.Migrations;

namespace future_1_.Migrations
{
    public partial class fleetPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorityPermit_PH",
                table: "fleets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackBus_license_PH",
                table: "fleets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontBus_license_PH",
                table: "fleets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorityPermit_PH",
                table: "fleets");

            migrationBuilder.DropColumn(
                name: "BackBus_license_PH",
                table: "fleets");

            migrationBuilder.DropColumn(
                name: "FrontBus_license_PH",
                table: "fleets");
        }
    }
}
