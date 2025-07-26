using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    public partial class PopularMusicas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var campos = new string[] { "Nome", "AnoLancamento" };

            migrationBuilder.InsertData("Musicas", campos,
                new object[] { "Smells Like Teen Spirit", "1991" });

            migrationBuilder.InsertData("Musicas", campos,
                new object[] { "Here, There And Everywhere", "1966" });

            migrationBuilder.InsertData("Musicas", campos,
                new object[] { "Iron Man", "1971" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Musicas");
        }
    }
}
