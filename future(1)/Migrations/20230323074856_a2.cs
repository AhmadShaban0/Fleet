using Microsoft.EntityFrameworkCore.Migrations;

namespace future_1_.Migrations
{
    public partial class a2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FleetId",
                table: "drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_drivers_FleetId",
                table: "drivers",
                column: "FleetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_drivers_fleets_FleetId",
                table: "drivers",
                column: "FleetId",
                principalTable: "fleets",
                principalColumn: "FleetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drivers_fleets_FleetId",
                table: "drivers");

            migrationBuilder.DropIndex(
                name: "IX_drivers_FleetId",
                table: "drivers");

            migrationBuilder.DropColumn(
                name: "FleetId",
                table: "drivers");
        }
    }
}
