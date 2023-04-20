using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Persistence.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Teams_TeamId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Week_WeekId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Week_Season_SeasonId",
                table: "Week");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Week",
                table: "Week");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Season",
                table: "Season");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Week",
                newName: "Weeks");

            migrationBuilder.RenameTable(
                name: "Season",
                newName: "Seasons");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameIndex(
                name: "IX_Week_SeasonId",
                table: "Weeks",
                newName: "IX_Weeks_SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_WeekId",
                table: "Games",
                newName: "IX_Games_WeekId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_TeamId",
                table: "Games",
                newName: "IX_Games_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weeks",
                table: "Weeks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GameMemberships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsHomeTeam = table.Column<bool>(type: "boolean", nullable: false),
                    createdTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMemberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameMemberships_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameMemberships_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameMemberships_GameId",
                table: "GameMemberships",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMemberships_TeamId",
                table: "GameMemberships",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_TeamId",
                table: "Games",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Weeks_WeekId",
                table: "Games",
                column: "WeekId",
                principalTable: "Weeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weeks_Seasons_SeasonId",
                table: "Weeks",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_TeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Weeks_WeekId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Weeks_Seasons_SeasonId",
                table: "Weeks");

            migrationBuilder.DropTable(
                name: "GameMemberships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weeks",
                table: "Weeks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Weeks",
                newName: "Week");

            migrationBuilder.RenameTable(
                name: "Seasons",
                newName: "Season");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameIndex(
                name: "IX_Weeks_SeasonId",
                table: "Week",
                newName: "IX_Week_SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_WeekId",
                table: "Game",
                newName: "IX_Game_WeekId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_TeamId",
                table: "Game",
                newName: "IX_Game_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Week",
                table: "Week",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Season",
                table: "Season",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Teams_TeamId",
                table: "Game",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Week_WeekId",
                table: "Game",
                column: "WeekId",
                principalTable: "Week",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Week_Season_SeasonId",
                table: "Week",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
