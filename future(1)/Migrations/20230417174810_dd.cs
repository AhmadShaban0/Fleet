using Microsoft.EntityFrameworkCore.Migrations;

namespace future_1_.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportationEntityAndSchoolRel_schools_SchoolId",
                table: "TransportationEntityAndSchoolRel");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportationEntityAndSchoolRel_transportationEntities_TransportationEntityId",
                table: "TransportationEntityAndSchoolRel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransportationEntityAndSchoolRel",
                table: "TransportationEntityAndSchoolRel");

            migrationBuilder.RenameTable(
                name: "TransportationEntityAndSchoolRel",
                newName: "TRS_Rel");

            migrationBuilder.RenameIndex(
                name: "IX_TransportationEntityAndSchoolRel_TransportationEntityId",
                table: "TRS_Rel",
                newName: "IX_TRS_Rel_TransportationEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TRS_Rel",
                table: "TRS_Rel",
                columns: new[] { "SchoolId", "TransportationEntityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TRS_Rel_schools_SchoolId",
                table: "TRS_Rel",
                column: "SchoolId",
                principalTable: "schools",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TRS_Rel_transportationEntities_TransportationEntityId",
                table: "TRS_Rel",
                column: "TransportationEntityId",
                principalTable: "transportationEntities",
                principalColumn: "TransportationEntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRS_Rel_schools_SchoolId",
                table: "TRS_Rel");

            migrationBuilder.DropForeignKey(
                name: "FK_TRS_Rel_transportationEntities_TransportationEntityId",
                table: "TRS_Rel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TRS_Rel",
                table: "TRS_Rel");

            migrationBuilder.RenameTable(
                name: "TRS_Rel",
                newName: "TransportationEntityAndSchoolRel");

            migrationBuilder.RenameIndex(
                name: "IX_TRS_Rel_TransportationEntityId",
                table: "TransportationEntityAndSchoolRel",
                newName: "IX_TransportationEntityAndSchoolRel_TransportationEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransportationEntityAndSchoolRel",
                table: "TransportationEntityAndSchoolRel",
                columns: new[] { "SchoolId", "TransportationEntityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TransportationEntityAndSchoolRel_schools_SchoolId",
                table: "TransportationEntityAndSchoolRel",
                column: "SchoolId",
                principalTable: "schools",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportationEntityAndSchoolRel_transportationEntities_TransportationEntityId",
                table: "TransportationEntityAndSchoolRel",
                column: "TransportationEntityId",
                principalTable: "transportationEntities",
                principalColumn: "TransportationEntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
