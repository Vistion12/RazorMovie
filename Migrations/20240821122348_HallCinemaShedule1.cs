using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorMovie.Migrations
{
    /// <inheritdoc />
    public partial class HallCinemaShedule1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HallCinemas",
                columns: table => new
                {
                    NumberHall = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountRows = table.Column<int>(type: "int", nullable: false),
                    CountSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallCinemas", x => x.NumberHall);
                });

            migrationBuilder.CreateTable(
                name: "Shedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartFilm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndFilm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    HallCinemaNumberHall = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shedules_HallCinemas_HallCinemaNumberHall",
                        column: x => x.HallCinemaNumberHall,
                        principalTable: "HallCinemas",
                        principalColumn: "NumberHall",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shedules_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shedules_HallCinemaNumberHall",
                table: "Shedules",
                column: "HallCinemaNumberHall");

            migrationBuilder.CreateIndex(
                name: "IX_Shedules_MovieId",
                table: "Shedules",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shedules");

            migrationBuilder.DropTable(
                name: "HallCinemas");
        }
    }
}
