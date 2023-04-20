using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Persistence.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Games",
                newName: "Stadium");

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamScore",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Games",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamScore",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "awayTeamId",
                table: "Games",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "homeTeamId",
                table: "Games",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Games_awayTeamId",
                table: "Games",
                column: "awayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_homeTeamId",
                table: "Games",
                column: "homeTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_awayTeamId",
                table: "Games",
                column: "awayTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_homeTeamId",
                table: "Games",
                column: "homeTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_awayTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_homeTeamId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_awayTeamId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_homeTeamId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AwayTeamScore",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HomeTeamScore",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "awayTeamId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "homeTeamId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Stadium",
                table: "Games",
                newName: "Name");
        }
    }
}
