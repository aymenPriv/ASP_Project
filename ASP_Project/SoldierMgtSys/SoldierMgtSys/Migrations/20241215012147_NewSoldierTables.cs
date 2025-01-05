using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoldierMgtSys.Migrations
{
    /// <inheritdoc />
    public partial class NewSoldierTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_TblSoldierInfo_SoldierId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSoldierInfo_Rank_RankId",
                table: "TblSoldierInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSoldierInfo_Unit_UnitId",
                table: "TblSoldierInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rank",
                table: "Rank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "TblUnits");

            migrationBuilder.RenameTable(
                name: "Rank",
                newName: "TblRanks");

            migrationBuilder.RenameTable(
                name: "Assignment",
                newName: "TblAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_Assignment_SoldierId",
                table: "TblAssignments",
                newName: "IX_TblAssignments_SoldierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblUnits",
                table: "TblUnits",
                column: "UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblRanks",
                table: "TblRanks",
                column: "RankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblAssignments",
                table: "TblAssignments",
                column: "AssignmentId");

            migrationBuilder.CreateTable(
                name: "TblDeployments",
                columns: table => new
                {
                    DeploymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeploymentLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeploymentStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeploymentEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoldierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDeployments", x => x.DeploymentId);
                    table.ForeignKey(
                        name: "FK_TblDeployments_TblSoldierInfo_SoldierId",
                        column: x => x.SoldierId,
                        principalTable: "TblSoldierInfo",
                        principalColumn: "SoldierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblDeployments_SoldierId",
                table: "TblDeployments",
                column: "SoldierId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAssignments_TblSoldierInfo_SoldierId",
                table: "TblAssignments",
                column: "SoldierId",
                principalTable: "TblSoldierInfo",
                principalColumn: "SoldierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSoldierInfo_TblRanks_RankId",
                table: "TblSoldierInfo",
                column: "RankId",
                principalTable: "TblRanks",
                principalColumn: "RankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSoldierInfo_TblUnits_UnitId",
                table: "TblSoldierInfo",
                column: "UnitId",
                principalTable: "TblUnits",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAssignments_TblSoldierInfo_SoldierId",
                table: "TblAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSoldierInfo_TblRanks_RankId",
                table: "TblSoldierInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSoldierInfo_TblUnits_UnitId",
                table: "TblSoldierInfo");

            migrationBuilder.DropTable(
                name: "TblDeployments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblUnits",
                table: "TblUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblRanks",
                table: "TblRanks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblAssignments",
                table: "TblAssignments");

            migrationBuilder.RenameTable(
                name: "TblUnits",
                newName: "Unit");

            migrationBuilder.RenameTable(
                name: "TblRanks",
                newName: "Rank");

            migrationBuilder.RenameTable(
                name: "TblAssignments",
                newName: "Assignment");

            migrationBuilder.RenameIndex(
                name: "IX_TblAssignments_SoldierId",
                table: "Assignment",
                newName: "IX_Assignment_SoldierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rank",
                table: "Rank",
                column: "RankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_TblSoldierInfo_SoldierId",
                table: "Assignment",
                column: "SoldierId",
                principalTable: "TblSoldierInfo",
                principalColumn: "SoldierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSoldierInfo_Rank_RankId",
                table: "TblSoldierInfo",
                column: "RankId",
                principalTable: "Rank",
                principalColumn: "RankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSoldierInfo_Unit_UnitId",
                table: "TblSoldierInfo",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
