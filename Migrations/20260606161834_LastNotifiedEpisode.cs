using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeNewsletter.Migrations
{
    /// <inheritdoc />
    public partial class LastNotifiedEpisode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastNotifiedEpisode",
                table: "UserAnime",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnimeUser",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "integer", nullable: false),
                    UsersEmail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeUser", x => new { x.AnimesId, x.UsersEmail });
                    table.ForeignKey(
                        name: "FK_AnimeUser_Anime_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeUser_Users_UsersEmail",
                        column: x => x.UsersEmail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeUser_UsersEmail",
                table: "AnimeUser",
                column: "UsersEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeUser");

            migrationBuilder.DropColumn(
                name: "LastNotifiedEpisode",
                table: "UserAnime");
        }
    }
}
