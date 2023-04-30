using Microsoft.EntityFrameworkCore.Migrations;

namespace future_1_.Migrations
{
    public partial class Relationship1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "transportationEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_transportationEntities_RegionId",
                table: "transportationEntities",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_transportationEntities_regions_RegionId",
                table: "transportationEntities",
                column: "RegionId",
                principalTable: "regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transportationEntities_regions_RegionId",
                table: "transportationEntities");

            migrationBuilder.DropIndex(
                name: "IX_transportationEntities_RegionId",
                table: "transportationEntities");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "transportationEntities");
        }
    }
}
