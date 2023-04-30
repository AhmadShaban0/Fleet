using Microsoft.EntityFrameworkCore.Migrations;

namespace future_1_.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportationEntityAndSchoolRel",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    TransportationEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationEntityAndSchoolRel", x => new { x.SchoolId, x.TransportationEntityId });
                    table.ForeignKey(
                        name: "FK_TransportationEntityAndSchoolRel_schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportationEntityAndSchoolRel_transportationEntities_TransportationEntityId",
                        column: x => x.TransportationEntityId,
                        principalTable: "transportationEntities",
                        principalColumn: "TransportationEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportationEntityAndSchoolRel_TransportationEntityId",
                table: "TransportationEntityAndSchoolRel",
                column: "TransportationEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportationEntityAndSchoolRel");
        }
    }
}
