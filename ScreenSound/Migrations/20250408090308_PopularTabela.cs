using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    public partial class PopularTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var campos = new string[] { "Nome", "Bio", "FotoPerfil" };

            migrationBuilder.InsertData("Artistas", campos,
                new object[] { "Nirvana", "banda grunge", "..." });

            migrationBuilder.InsertData("Artistas", campos,
                new object[] { "Beatles", "maior banda de todos os tempos", "..." });

            migrationBuilder.InsertData("Artistas", campos,
                new object[] { "Black Sabbath", "I am iron man", "..." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artistas");
        }
    }
}
