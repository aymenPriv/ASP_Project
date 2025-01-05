using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoldierMgtSys.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabaseChanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSoldierInfo_TblRanks_RankId",
                table: "TblSoldierInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSoldierInfo_TblUnits_UnitId",
                table: "TblSoldierInfo");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "TblSoldierInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RankId",
                table: "TblSoldierInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_TblSoldierInfo_TblRanks_RankId",
                table: "TblSoldierInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSoldierInfo_TblUnits_UnitId",
                table: "TblSoldierInfo");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "TblSoldierInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RankId",
                table: "TblSoldierInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSoldierInfo_TblRanks_RankId",
                table: "TblSoldierInfo",
                column: "RankId",
                principalTable: "TblRanks",
                principalColumn: "RankId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSoldierInfo_TblUnits_UnitId",
                table: "TblSoldierInfo",
                column: "UnitId",
                principalTable: "TblUnits",
                principalColumn: "UnitId");
        }
    }
}
