using Microsoft.EntityFrameworkCore.Migrations;

namespace future_1_.Migrations
{
    public partial class c1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "effectiveness",
                table: "fleets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FleetState",
                table: "fleets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TransportationEntityId",
                table: "fleets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_fleets_TransportationEntityId",
                table: "fleets",
                column: "TransportationEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_fleets_transportationEntities_TransportationEntityId",
                table: "fleets",
                column: "TransportationEntityId",
                principalTable: "transportationEntities",
                principalColumn: "TransportationEntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fleets_transportationEntities_TransportationEntityId",
                table: "fleets");

            migrationBuilder.DropIndex(
                name: "IX_fleets_TransportationEntityId",
                table: "fleets");

            migrationBuilder.DropColumn(
                name: "TransportationEntityId",
                table: "fleets");

            migrationBuilder.AlterColumn<int>(
                name: "effectiveness",
                table: "fleets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FleetState",
                table: "fleets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
