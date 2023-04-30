using Microsoft.EntityFrameworkCore.Migrations;

namespace future_1_.Migrations
{
    public partial class updateschool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SchoolType",
                table: "schools",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_schools_RegionId",
                table: "schools",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_schools_regions_RegionId",
                table: "schools",
                column: "RegionId",
                principalTable: "regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schools_regions_RegionId",
                table: "schools");

            migrationBuilder.DropIndex(
                name: "IX_schools_RegionId",
                table: "schools");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "schools");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolType",
                table: "schools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
