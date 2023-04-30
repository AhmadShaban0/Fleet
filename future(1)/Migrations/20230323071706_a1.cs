using Microsoft.EntityFrameworkCore.Migrations;

namespace future_1_.Migrations
{
    public partial class a1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "drivers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccessNumber",
                table: "drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransportationEntityId",
                table: "drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_drivers_TransportationEntityId",
                table: "drivers",
                column: "TransportationEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_drivers_transportationEntities_TransportationEntityId",
                table: "drivers",
                column: "TransportationEntityId",
                principalTable: "transportationEntities",
                principalColumn: "TransportationEntityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drivers_transportationEntities_TransportationEntityId",
                table: "drivers");

            migrationBuilder.DropIndex(
                name: "IX_drivers_TransportationEntityId",
                table: "drivers");

            migrationBuilder.DropColumn(
                name: "AccessNumber",
                table: "drivers");

            migrationBuilder.DropColumn(
                name: "TransportationEntityId",
                table: "drivers");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "drivers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
