using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmListBlazor.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Watch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HappinessScale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmList_Watch_WatchId",
                        column: x => x.WatchId,
                        principalTable: "Watch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Watch",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Sim" });

            migrationBuilder.InsertData(
                table: "Watch",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Não" });

            migrationBuilder.InsertData(
                table: "FilmList",
                columns: new[] { "Id", "DurationTime", "Gender", "HappinessScale", "Title", "Type", "WatchId" },
                values: new object[] { 1, "22 min", "Drama Psicológico", "10", "How I Met Your Mother", "Série", 1 });

            migrationBuilder.InsertData(
                table: "FilmList",
                columns: new[] { "Id", "DurationTime", "Gender", "HappinessScale", "Title", "Type", "WatchId" },
                values: new object[] { 2, "115 min", "Drama Psicológico", "10", "A Baleia", "Filme", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_FilmList_WatchId",
                table: "FilmList",
                column: "WatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmList");

            migrationBuilder.DropTable(
                name: "Watch");
        }
    }
}
